using EntityLayer.Entities.HelperEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Contact:Entity
    {
        public Address? Address { get; set; }
        public string? Email { get; set; }
        public List<SocialMedia>? SocialMediaAccounts { get; set; }
        public List<Phone>? PhoneNumbers { get; set; }
    }
}
