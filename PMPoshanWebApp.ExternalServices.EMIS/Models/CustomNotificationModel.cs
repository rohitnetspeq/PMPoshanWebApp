using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
    public class NotificationViewModel
    {
        public long NotificationID { get; set; }
        public string NotificationTitle { get; set; }
        public string FilePath { get; set; }
    }

    public class CustomNotificationModel
    {
        public IEnumerable<NotificationViewModel> NotificationList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
