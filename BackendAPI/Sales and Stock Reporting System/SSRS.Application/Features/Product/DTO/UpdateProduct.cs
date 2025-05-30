﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSRS.Application.Features.Product.DTO
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public string? Description { get; set; }
    }
}
