using SteamStoreAPI;
using SteamStoreAPI.Models;
using System.Diagnostics;

namespace WishlistAppUnitTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public async Task TestSteamAppApi() {
            SteamApp comparisonApp = new SteamApp {
                Title = "Balatro",
                AppId = 2379780,
                InitialPrice = 1399,
            };

            DataClient client = new DataClient();
            SteamApp app = await client.GetSteamApp(comparisonApp.AppId);

            Assert.AreEqual(app.Title, comparisonApp.Title);
            Assert.AreEqual(app.AppId, comparisonApp.AppId);
            Assert.AreEqual(app.InitialPrice, comparisonApp.InitialPrice);


        }

        [TestMethod]
        public async Task TestFakeGame() {
            DataClient client = new DataClient();
            SteamApp app = await client.GetSteamApp(999999999);

            Assert.IsNull(app);
        }
    }
}