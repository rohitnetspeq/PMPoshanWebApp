using PMPoshanWebApp.Integrations.EMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMPoshanWebApp.Integrations.EMIS.Interfaces
{
    public interface IEmisApiClient
    {
        Task<List<BannerViewModel>> GetAllBanners();
        Task<CustomKCMSModel> GetCMSContentByName(string contnentName);
        Task<List<CustomLinkViewModel>> GetAllLinks();
        Task<CustomNotificationModel> GetNotificationPaged(int pageno, int pagesize, string searchTerm);
        //Task<CustomPhotoAlbumModel> GetPhotoAlbumsPaged(int pageno, int pagesize, string searchTerm);
        //Task<CustomPhotoAlbumInfoViewModel> GetAlbumPhotosById(long photosById);
        //Task<CustomEventModel> GetEventsPaged(int pageno, int pagesize, string searchTerm);
        //Task<EventViewModel> GetEventById(long eventId);
        //Task<CustomVideoModel> GetVideoAlbumsPaged(int pageno, int pagesize, string searchTerm);
        //Task<VideoInfoViewModel> GetAlbumVideosById(long videoId);
    }
}
