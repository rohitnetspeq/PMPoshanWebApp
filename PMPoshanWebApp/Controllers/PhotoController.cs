using Microsoft.AspNetCore.Mvc;

namespace PMPoshanWebApp.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PhotoGallery()
        {
            return View();
        }
    }
}
