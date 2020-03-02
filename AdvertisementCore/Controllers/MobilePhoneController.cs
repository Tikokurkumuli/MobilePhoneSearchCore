using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<MainViewModel> viewModels = new List<MainViewModel>();
        MainViewModel mainViewModel = new MainViewModel();
        public MobilePhoneController(IMobilePhoneApiHelper apiHelper, IManufacturerApiHelper manufHelper)
        {
            _apiHelper = apiHelper;
            _manufHelper = manufHelper;
        }
        public async Task<IActionResult> Index(Filter filter)
        {
            var mobilePhones = await _apiHelper.GetMobilePhones(filter);
            var manufacturers = await _manufHelper.GetManufacturers();
            mainViewModel.MobilePhones = mobilePhones;
            mainViewModel.Manufacturers = manufacturers;

            return View(mainViewModel);
        }
        public ActionResult Details(MobilePhone data)
        {
            return View(data);
        }
    }
}