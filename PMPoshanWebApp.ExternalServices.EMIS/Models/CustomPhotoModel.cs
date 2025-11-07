using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    
    public class CustomPhotoAlbumModel
    {
        public IEnumerable<AlbumViewModel> Albums { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
    public class AlbumViewModel
    {
        public long PhotoAlbumID { get; set; }
        public string PhotoAlbumDesc { get; set; }
        public int PhotoCount { get; set; }
        public string CoverThumb { get; set; }
    }

    public class CustomPhotoAlbumInfoViewModel
    {
        public long PhotoID { get; set; }
        public long PhotoAlbumID { get; set; }
        public string PhotoCaption { get; set; }
        public string PhotoThumb { get; set; }
        public string PhotoPath { get; set; }
        public bool IsAlbumCover { get; set; }

    }
}
