using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class PhotoVM
    {
        public CustomPhotoAlbumModel PhotoAlbums { get; set; }
        
    }

    public class PhotoGallery
    {
        public List<CustomPhotoAlbumInfoViewModel> Photos { get; set; }
    }
}
