using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        [DisallowNull]
        public int ParentId { get; set; }

    }
}
