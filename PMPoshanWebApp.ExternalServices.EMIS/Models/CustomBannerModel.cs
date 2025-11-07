using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class BannerViewModel
    {
        public long BannerID { get; set; }
        public string BannerTitle { get; set; }
        public string BannerThumb { get; set; }

        public string BannerPath { get; set; }
    }
}
