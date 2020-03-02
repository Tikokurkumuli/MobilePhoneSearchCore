using AdvertisementCore.Models;
using AdvertisementCore.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdvertisementCore.Helper
{
    public class ManufacturerHelper1
    {
        public interface IManufacturerApiHelper
        {
            Task<List<Manufacturer>> GetManufacturers();
        }
        public class ManufacturerHelper : IManufacturerApiHelper
        {
            private readonly ApiOptions _options;
            public ManufacturerHelper(IOptions<ApiOptions> options)
            {
                _options = options.Value;
            }

            public async Task<List<Manufacturer>> GetManufacturers()
            {
                var result = new List<Manufacturer>();
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(_options.Url1);

                    if (response.IsSuccessStatusCode)
                    {
                        result = JsonConvert.DeserializeObject<List<Manufacturer>>(response.Content.ReadAsStringAsync().Result);


                    }
                }
                return result;
            }
        }
    }
}
