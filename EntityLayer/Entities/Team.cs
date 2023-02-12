using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Team:Entity
    {
        public string? MemberFullName { get; set; }
        public string? MemberPosition { get; set; }

    }
}
