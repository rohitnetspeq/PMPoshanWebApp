using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMPoshanWebApp.Integrations.EMIS.Interfaces;
using PMPoshanWebApp.Integrations.EMIS.Models;

namespace PMPoshanWebApp.Controllers
{
    public class VideosController : Controller
    {
        private readonly ILogger<VideosController> _logger;
        private readonly IEmisApiClient _emisApiClient;
        private readonly IConfiguration _configuration;

        public VideosController(ILogger<VideosController> logger, IEmisApiClient emisApiClient, IConfiguration configuration)
        {
            _logger = logger;
            _emisApiClient = emisApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var videoAlbum = await _emisApiClient.GetVideoAlbumsPaged(pageNo, 8, "");

            var model = new VideoVM
            {

                VideoAlbums = videoAlbum
            };

            return View(model);
        }

        public async Task<IActionResult> VideoGallery(long albumId)
        {
            var videoGallery = await _emisApiClient.GetAlbumVideosById(albumId);

            var model = new VideoGallery
            {

                Videos = videoGallery
            };

            return View(model);
        }
    }
}
