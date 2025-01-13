using RestSharp;
using SteamStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamStoreAPI {
    public class DataClient {

        RestClient restClient;
        const string baseUrl = "https://store.steampowered.com/api/appdetails/";
        public DataClient() {
            restClient = new RestClient(baseUrl);
        
        }

        public async Task<SteamApp> GetSteamApp(int appId) {
            RestRequest request = new RestRequest().AddParameter("appids", appId);

            RestResponse response = await restClient.ExecuteGetAsync(request);

            var data = JsonSerializer.Deserialize<Dictionary<string, AppData>>(response.Content!, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                Converters = { new SteamAppJsonConverter() }
            })!;
            if(data.ContainsKey(appId.ToString())) {
                var appData = data[appId.ToString()];

                if (appData.success == false) return null;

                SteamApp app = appData.data!;
                app.AppId = appId;
                return app!;
            }

            

            return null;
        }

        private class AppData {
            public bool success { get; set; }
            public SteamApp? data { get; set; }
        }

        private class SteamAppJsonConverter : JsonConverter<SteamApp> {
            public override SteamApp? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
                SteamApp steamApp = new SteamApp();
                using (JsonDocument doc = JsonDocument.ParseValue(ref reader)) {
                    JsonElement root = doc.RootElement;

                    steamApp.Title = root.GetProperty("name").GetString();
                    steamApp.IsFree = root.GetProperty("is_free").GetBoolean();
                    steamApp.AppId = root.GetProperty("steam_appid").GetInt32();
                    steamApp.HeaderUrl = root.GetProperty("header_image").GetString();

                    if (root.TryGetProperty("price_overview", out JsonElement priceOverview)) {
                        steamApp.Currency = priceOverview.GetProperty("currency").GetString();
                        steamApp.InitialPrice = priceOverview.GetProperty("initial").GetInt32();
                        steamApp.FinalPrice = priceOverview.GetProperty("final").GetInt32();
                        steamApp.DiscountPercent = priceOverview.GetProperty("discount_percent").GetInt32();
                        steamApp.InitialPriceFormatted = priceOverview.GetProperty("initial_formatted").GetString();
                        steamApp.FinalPriceFormatted = priceOverview.GetProperty("final_formatted").GetString();
                    }
                }
                return steamApp;
            }

            public override void Write(Utf8JsonWriter writer, SteamApp value, JsonSerializerOptions options) {
                throw new NotImplementedException();
            }
        }
    }
}
