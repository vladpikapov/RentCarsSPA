using System;
using System.Collections.Generic;

namespace RestCarsSPA
{
    public partial class Drivers
    {
        public Drivers()
        {
            Orders = new HashSet<Orders>();
        }

        public string NumberDriverLicense { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
