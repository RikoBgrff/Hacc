﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DisallowNull]
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool HaveImg { get; set; }
        public string? ImageUrl { get; set; }
        public int Status { get; set; }
    }
}