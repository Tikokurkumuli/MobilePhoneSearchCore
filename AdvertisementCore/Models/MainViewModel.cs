using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementCore.Models
{
    public class MainViewModel
    {
        public List<MobilePhone> MobilePhones { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public Filter Filter { get; set; }
    }
}
