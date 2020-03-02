using AdvertisementCore.Models;
using AdvertisementCore.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static AdvertisementCore.Helper.ManufacturerHelper1;

namespace AdvertisementCore.Helper
{
    public class PhoneHelper
    {
        public interface IMobilePhoneApiHelper
        {
            Task<List<MobilePhone>> GetMobilePhones(Filter filter);
        }
        public class MobilePhonesApiHelper : IMobilePhoneApiHelper
        {
            private readonly ApiOptions _options;
            private readonly IManufacturerApiHelper _apiManufHelper;
            public MobilePhonesApiHelper(IOptions<ApiOptions> options, IManufacturerApiHelper apiManufHelper)
            {
                _options = options.Value;
                _apiManufHelper = apiManufHelper;
            }

            public async Task<List<MobilePhone>> GetMobilePhones(Filter filter)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(_options.Url);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<List<MobilePhone>>(response.Content.ReadAsStringAsync().Result);
                        foreach (var item in result)
                        {
                            item.Manufacturers = await _apiManufHelper.GetManufacturers();
                        }
                        return result;
                    }
                }
                return null;
            }
        }
    }
}
