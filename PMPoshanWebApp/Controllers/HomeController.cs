using Microsoft.AspNetCore.Mvc;
using PMPoshanWebApp.Integrations.EMIS.Interfaces;
using PMPoshanWebApp.Integrations.EMIS.Models;
using PMPoshanWebApp.Integrations.EMIS.Services;
using PMPoshanWebApp.Models;
using System.Diagnostics;

namespace PMPoshanWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmisApiClient _emisApiClient;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IEmisApiClient emisApiClient, IConfiguration configuration)
        {
            _logger = logger;
            _emisApiClient = emisApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var webUrl = _configuration["EmisApi:WebUrl"];
            // Pass it to the view via ViewData or ViewBag or in your model
            ViewData["WebFileBaseUrl"] = webUrl;

            var banners = await _emisApiClient.GetAllBanners();
            var aboutUsContent = await _emisApiClient.GetCMSContentByName("About Us");
            var cmContent = await _emisApiClient.GetCMSContentByName("Hon'ble Chief Minister");
            var governorContent = await _emisApiClient.GetCMSContentByName("Hon'ble Governor");
            var g20Content = await _emisApiClient.GetCMSContentByName("G20");
            var ratesContent = await _emisApiClient.GetCMSContentByName("Latest Rates");
            var approachesContent = await _emisApiClient.GetCMSContentByName("Approaches");
            var objectivesContent = await _emisApiClient.GetCMSContentByName("Objectives");
            var links = await _emisApiClient.GetAllLinks();
            var notification = await _emisApiClient.GetNotificationPaged(1,2,"");
            var model = new HomePageViewModel {
                Banners = banners,
                AboutUs = aboutUsContent,
                CM = cmContent,
                Governor = governorContent,
                G20 = g20Content,
                LatestRates = ratesContent,
                Approaches = approachesContent,
                Objectives = objectivesContent,
                Links = links,
                Notification = notification
            };


           

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
