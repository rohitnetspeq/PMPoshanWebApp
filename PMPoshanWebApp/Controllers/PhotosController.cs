using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMPoshanWebApp.Integrations.EMIS.Interfaces;
using PMPoshanWebApp.Integrations.EMIS.Models;

namespace PMPoshanWebApp.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IEmisApiClient _emisApiClient;
        private readonly IConfiguration _configuration;

        public PhotosController(ILogger<PhotosController> logger, IEmisApiClient emisApiClient, IConfiguration configuration)
        {
            _logger = logger;
            _emisApiClient = emisApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var photoAlbum = await _emisApiClient.GetPhotoAlbumsPaged(pageNo, 8, "");

            var model = new PhotoVM
            {
                
                PhotoAlbums = photoAlbum,
            };

            return View(model);
        }

        public async Task<IActionResult> PhotoGallery(long albumId)
        {
            var photoGallery = await _emisApiClient.GetAlbumPhotosById(albumId);

            var model = new PhotoGallery
            {

                Photos = photoGallery,
            };

            
            return View(model);
        }
    }
}
