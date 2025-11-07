using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class CustomKCMSModel
    {
        public long KCMContentID { get; set; }
        public string KCMContentName { get; set; }
        public string KCMContent { get; set; }

        public string KCMImageThumb { get; set; }
        public string KCMImagePath { get; set; }

    }
}
