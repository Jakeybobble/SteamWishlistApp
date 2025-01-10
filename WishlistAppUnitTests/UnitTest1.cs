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
                Id = "2379780",
            };

            DataClient client = new DataClient();
            SteamApp app = await client.GetSteamApp(comparisonApp.Id);

            Assert.AreEqual(app.Title, comparisonApp.Title);
            Assert.AreEqual(app.Id, comparisonApp.Id);


        }

        [TestMethod]
        public async Task TestFakeGame() {
            DataClient client = new DataClient();
            SteamApp app = await client.GetSteamApp("9999999999999");

            Assert.IsNull(app);
        }
    }
}