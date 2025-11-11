namespace PMPoshanWebApp.Helpers
{
    public static class YoutubeHelper
    {
        public static string GetYoutubeThumbnail(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";

            var uri = new Uri(url);

            if (uri.Host.Contains("youtube.com") && uri.Query.Contains("v="))
            {
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                var videoId = query["v"];
                return $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
            }

            if (uri.Host.Contains("youtu.be"))
            {
                var videoId = uri.AbsolutePath.Trim('/');
                return $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
            }

            return "";
        }
    }
}
