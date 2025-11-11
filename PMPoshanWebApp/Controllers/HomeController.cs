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

        public async Task<IActionResult> Index(int eventPage = 1, int notificationPage = 1)
        {
            var banners = await _emisApiClient.GetAllBanners();
            var aboutUsContent = await _emisApiClient.GetCMSContentByName("About Us");
            var cmContent = await _emisApiClient.GetCMSContentByName("Hon'ble Chief Minister");
            var governorContent = await _emisApiClient.GetCMSContentByName("Hon'ble Governor");
            var g20Content = await _emisApiClient.GetCMSContentByName("G20");
            var ratesContent = await _emisApiClient.GetCMSContentByName("Latest Rates");
            var approachesContent = await _emisApiClient.GetCMSContentByName("Approaches");
            var objectivesContent = await _emisApiClient.GetCMSContentByName("Objectives");
            var links = await _emisApiClient.GetAllLinks();
            var notification = await _emisApiClient.GetNotificationPaged(notificationPage, 5, "");
            var events = await _emisApiClient.GetEventsPaged(eventPage, 5, "");
            var photoAlbum = await _emisApiClient.GetPhotoAlbumsPaged(1, 4, "");
            var videoAlbum = await _emisApiClient.GetVideoAlbumsPaged(1, 4, "");

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
                Notifications = notification,
                Events = events,
                PhotoAlbums = photoAlbum,
                VideoAlbums = videoAlbum
            };


           

            return View(model);
        }

        public async Task<IActionResult> LoadEvents(int page = 1)
        {
            var events = await _emisApiClient.GetEventsPaged(page, 5, "");
            return PartialView("_EventsPartial", events);
        }
        public async Task<IActionResult> EventsListPartial(int eventPage = 1)
        {
            var events = await _emisApiClient.GetEventsPaged(eventPage, 5, "");

            var model = new CustomEventModel
            {
                EventList = events.EventList,
                PagingInfo = events.PagingInfo
            };

            return PartialView("_EventsPartial", model);
        }

        public async Task<IActionResult> NotificationsListPartial(int notificationPage = 1)
        {
            var notifications = await _emisApiClient.GetNotificationPaged(notificationPage, 5, "");

            var model = new CustomNotificationModel
            {
                NotificationList = notifications.NotificationList,
                PagingInfo = notifications.PagingInfo
            };

            return PartialView("_NotificationsPartial", model);
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
