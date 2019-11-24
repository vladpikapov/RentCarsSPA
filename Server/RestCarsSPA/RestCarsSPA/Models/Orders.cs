using System;
using System.Collections.Generic;

namespace RestCarsSPA
{
    public partial class Orders
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public string DriverLicense { get; set; }
        public string CarId { get; set; }

        public  Cars Car { get; set; }
        public  Drivers Driver { get; set; }
    }
}
