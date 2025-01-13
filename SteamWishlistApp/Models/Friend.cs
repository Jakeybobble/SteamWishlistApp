using SteamStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWishlistApp.Models {
    public class Friend {
        public string Name { get; set; }
        public ObservableCollection<SteamApp> Games { get; set; } = new ObservableCollection<SteamApp>();

    }
}
