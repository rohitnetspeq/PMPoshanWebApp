using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class HomePageViewModel
    {
        public List<BannerViewModel> Banners { get; set; }
        public CustomKCMSModel AboutUs { get; set; }
        public CustomKCMSModel CM { get; set; }
        public CustomKCMSModel Governor { get; set; }
        public CustomKCMSModel G20 { get; set; }
        public CustomKCMSModel LatestRates { get; set; }
        public CustomKCMSModel Objectives { get; set; }
        public CustomKCMSModel Approaches { get; set; }
        public List<CustomLinkViewModel> Links { get; set; }
        public CustomNotificationModel Notifications { get; set; }
        public CustomEventModel Events { get; set; }
        public CustomPhotoAlbumModel PhotoAlbums { get; set; }
        public CustomVideoModel VideoAlbums { get; set; }

    }

}
