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
        const string baseUrl = "";
        public DataClient() {
            restClient = new RestClient(baseUrl);
        
        }

        public async Task<SteamApp> GetSteamApp(int appId) {
            RestRequest request = new RestRequest().AddParameter("appids", appId);

            RestResponse response = await restClient.ExecuteGetAsync(request);

            SteamApp app = JsonSerializer.Deserialize<SteamApp>(response.Content!)!;

            return app;
        }
    }
}
