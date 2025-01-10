﻿using SteamStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWishlistApp.Models {
    public class Friend {
        public string Name { get; set; }
        public List<SteamApp> Games { get; set; } = new List<SteamApp>();

    }
}
