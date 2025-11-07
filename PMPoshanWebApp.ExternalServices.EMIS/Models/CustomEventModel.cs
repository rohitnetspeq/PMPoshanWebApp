using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Models
{
   
    public class EventInfoViewModel
    {
        public long EventID { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string FilePath { get; set; }
    }

    public class CustomEventModel
    {
        public IEnumerable<EventInfoViewModel> EventList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class EventViewModel
    {
        public long EventID { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string FilePath { get; set; }
    }


}
