using System;
using System.Collections.Generic;

namespace RestCarsSPA
{
    public partial class Cars
    {
        public Cars()
        {
            Orders = new HashSet<Orders>();
        }

        public string RegistrationNumber { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string CarClass { get; set; }
        public DateTime YearOfIssue { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
