using PMPoshanWebApp.Integrations.EMIS.Interfaces;
using PMPoshanWebApp.Integrations.EMIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PMPoshanWebApp.Integrations.EMIS.Services
{

    public class EmisApiClient : IEmisApiClient
    {
        private readonly HttpClient _httpClient;

        public EmisApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<BannerViewModel>> GetAllBanners()
        {
            try
            {
                var requestUrl = $"pmpgeneralapi/GeneralPublicPMP/GetAllPublicBanners";
                var response = await _httpClient.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<BannerViewModel>>(json)
                       ?? new List<BannerViewModel>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling EMIS API: {ex.Message}", ex);
            }
        }

        public async Task<CustomKCMSModel> GetCMSContentByName(string contnentName)
        {
            try
            {
                var requestUrl = $"pmpgeneralapi/GeneralPublicPMP/GetPublicCMSContentByName?name={contnentName}";
                var response = await _httpClient.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CustomKCMSModel>(json)
                       ?? new CustomKCMSModel();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling EMIS API: {ex.Message}", ex);
            }
        }

        public async Task<List<CustomLinkViewModel>> GetAllLinks()
        {
            try
            {
                var requestUrl = $"pmpgeneralapi/GeneralPublicPMP/GetAllPublicLinks";
                var response = await _httpClient.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CustomLinkViewModel>>(json)
                       ?? new List<CustomLinkViewModel>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling EMIS API: {ex.Message}", ex);
            }
        }

        public async Task<CustomNotificationModel> GetNotificationPaged(int pageno, int pagesize, string searchTerm = "")
        {
            try
            {
                var requestUrl = $"pmpgeneralapi/GeneralPublicPMP/GetPublicNotificationPaged?pageno={pageno}&pagesize={pagesize}&searchTerm={searchTerm}";
                var response = await _httpClient.GetAsync(requestUrl);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<CustomNotificationModel>(json)
                       ?? new CustomNotificationModel();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calling EMIS API: {ex.Message}", ex);
            }
        }
    }
}
