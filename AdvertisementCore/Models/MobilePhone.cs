using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementCore.Models
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public int? Weight { get; set; }
        public decimal? ScreeenSize { get; set; }
        public string Resolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string OperatingSystem { get; set; }
        public int? Price { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int ManufacturerId { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }

    }

}
