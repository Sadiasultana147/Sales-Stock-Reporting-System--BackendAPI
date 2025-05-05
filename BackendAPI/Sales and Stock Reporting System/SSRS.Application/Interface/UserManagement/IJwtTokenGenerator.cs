using SSRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Interface.UserManagement
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }

}
