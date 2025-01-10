using RestSharp;
using SteamStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamStoreAPI {
    public class DataClient {

        RestClient restClient;
        const string baseUrl = "https://store.steampowered.com/api/appdetails/";
        public DataClient() {
            restClient = new RestClient(baseUrl);
        
        }

        public async Task<SteamApp> GetSteamApp(string appId) {
            RestRequest request = new RestRequest().AddParameter("appids", appId);

            RestResponse response = await restClient.ExecuteGetAsync(request);

            var data = JsonSerializer.Deserialize<Dictionary<string, AppData>>(response.Content!)!;
            if(data.ContainsKey(appId.ToString())) {
                var appData = data[appId.ToString()];
                SteamApp app = appData.data!;
                app.Id = appId;
                return app!;
            }

            

            return null!;
        }

        private class AppData {
            public bool success { get; set; }
            public SteamApp? data { get; set; }
        }
    }
}
