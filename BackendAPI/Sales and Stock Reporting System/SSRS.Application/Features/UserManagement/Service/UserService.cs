using SSRS.Application.Features.UserManagement.DTO;
using SSRS.Application.Interface.UserManagement;
using SSRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Features.UserManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenGenerator _tokenGen;

        public UserService(IUserRepository userRepo, IJwtTokenGenerator tokenGen)
        {
            _userRepo = userRepo;
            _tokenGen = tokenGen;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterUserDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            await _userRepo.AddUserAsync(user);
            var token = _tokenGen.GenerateToken(user);
            return new AuthResponseDTO { Username = user.Username, Token = token };
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginUserDTO dto)
        {
            var user = await _userRepo.GetByUsernameAsync(dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var token = _tokenGen.GenerateToken(user);
            return new AuthResponseDTO { Username = user.Username, Token = token };
        }
    }
}
