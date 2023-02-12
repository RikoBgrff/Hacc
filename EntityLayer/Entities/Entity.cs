using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public int HasImg { get; set; }
        public string? ImageText { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}
