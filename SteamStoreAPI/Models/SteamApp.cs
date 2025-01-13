using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamStoreAPI.Models {
    public class SteamApp {

        public string Title { get; set; }
        public int AppId { get; set; }

        public bool IsFree { get; set; }
        public string HeaderUrl { get; set; }

        // Price overview
        public string Currency {  get; set; }
        public int InitialPrice {  get; set; }
        public int FinalPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string InitialPriceFormatted { get; set; }
        public string FinalPriceFormatted { get; set; }

        public bool IsDiscounted => DiscountPercent > 0;

        

    }
}
