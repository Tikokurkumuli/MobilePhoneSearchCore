using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementCore.Models
{
    public class Filter
    {
        public string MobileName { get; set; }
        public string ManufacturerName { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
    }
}
