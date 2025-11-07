using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{

    public class CustomVideoModel
    {
        public IEnumerable<VideoViewModel> Albums { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
    public class VideoViewModel
    {
        public long VideoAlbumID { get; set; }
        public string VideoAlbumDesc { get; set; }
        public int VideoCount { get; set; }
        public string VideoCoverLink { get; set; }
    }

    public class VideoInfoViewModel
    {
        public long VideoID { get; set; }
        public long VideoAlbumID { get; set; }
        public string VideoCaption { get; set; }
        public string VideoLink { get; set; }
        public bool IsAlbumCover { get; set; }
    }
}
