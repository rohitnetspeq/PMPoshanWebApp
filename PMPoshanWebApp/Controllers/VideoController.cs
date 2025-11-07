using Microsoft.AspNetCore.Mvc;

namespace PMPoshanWebApp.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VideoGallery()
        {
            return View();
        }
    }
}
