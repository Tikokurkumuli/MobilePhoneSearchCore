using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementCore.Client;
using AdvertisementCore.Models;
using Microsoft.AspNetCore.Mvc;
using static AdvertisementCore.Helper.ManufacturerHelper1;
using static AdvertisementCore.Helper.PhoneHelper;

namespace AdvertisementCore.Controllers
{
    public class MobilePhoneController : Controller
    {
        private readonly IMobilePhoneApiHelper _apiHelper;
        private readonly IManufacturerApiHelper _manufHelper;
        private readonly PhoneSearchClient _phoneSearchClient;


        public List<MainViewModel> viewModels = new List<MainViewModel>();
        MainViewModel mainViewModel = new MainViewModel();
        public MobilePhoneController(IMobilePhoneApiHelper apiHelper, IManufacturerApiHelper manufHelper, PhoneSearchClient phoneSearchClient)
        {
            _apiHelper = apiHelper;
            _manufHelper = manufHelper;
            _phoneSearchClient = phoneSearchClient;
        }
        public async Task<IActionResult> Index(Filter filter)
        {
            var mobilePhones = await _apiHelper.GetMobilePhones(filter);
            var manufacturers = await _manufHelper.GetManufacturers();
            mainViewModel.MobilePhones = mobilePhones;
            mainViewModel.Manufacturers = manufacturers;

            return View(mainViewModel);
        }

        public async Task<IActionResult> Test()
        {
            await _phoneSearchClient.Manufacturer_GetAsync();

            return null;
        }
        public ActionResult Details(MobilePhone data)
        {
            return View(data);
        }
    }
}