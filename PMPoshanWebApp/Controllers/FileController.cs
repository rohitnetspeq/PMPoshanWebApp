using Microsoft.AspNetCore.Mvc;

namespace PMPoshanWebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public FileController(IHttpClientFactory httpClientFactory, IWebHostEnvironment env, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _env = env;
            _configuration = configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("File/Download")]
        public async Task<IActionResult> Download(string fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                    return BadRequest("File name is required.");

                // Security: Extract only the file name (last part of the path)
                var safeFileName = Path.GetFileName(fileName);

                if (safeFileName != fileName && !fileName.EndsWith("/" + safeFileName))
                    return BadRequest("Invalid file name.");

                // Build correct external URL
                var baseUrl = _configuration["EmisApi:WebUrl"].TrimEnd('/');
                var fileUrl = $"{baseUrl}{fileName}"; // IMPORTANT: use filePath as-is

                var response = await _httpClient.GetAsync(fileUrl);

                if (!response.IsSuccessStatusCode)
                    return NotFound("File not found.");

                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var contentType = response.Content.Headers.ContentType?.MediaType ?? GetContentType(safeFileName);

                return File(fileBytes, contentType);
            }
            catch
            {
                return StatusCode(500, "An error occurred while downloading the file.");
            }
        }


        private string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".png" => "image/png",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".txt" => "text/plain",
                ".csv" => "text/csv",
                ".zip" => "application/zip",
                ".rar" => "application/x-rar-compressed",
                _ => "application/octet-stream"
            };
        }
    }

}
