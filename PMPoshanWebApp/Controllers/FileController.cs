using Microsoft.AspNetCore.Mvc;

namespace PMPoshanWebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("File/Download")]
        public async Task<IActionResult> Download(string fileName)
        {
            // You can add your security checks here, e.g.:
            // - Check if user is authorized
            // - Check if fileName is valid/safe
            // - Log the download attempt

            if (string.IsNullOrEmpty(fileName))
                return BadRequest();

            // Build full path to the file on server
            var filePath = Path.Combine(_env.WebRootPath, "notification_files", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            // Determine content type (you can use a better way here)
            var contentType = "application/octet-stream";

            return File(memory, contentType, Path.GetFileName(filePath));
        }
    }

}
