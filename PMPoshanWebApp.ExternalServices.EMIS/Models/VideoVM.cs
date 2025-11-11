using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class VideoVM
    {
        public CustomVideoModel VideoAlbums { get; set; }

    }

    public class VideoGallery
    {
        public List<VideoInfoViewModel> Videos { get; set; }
    }
}
