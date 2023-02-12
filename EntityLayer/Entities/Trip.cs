using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Trip:Entity
    {
        public DateTime RegistrationDeadline { get; set; }
        public DateTime EstimatedTripDate { get; set; }
        public string? FullDescription { get; set; }
        public int TripType { get; set; }
        public string? Icon { get; set; }
    }
}
