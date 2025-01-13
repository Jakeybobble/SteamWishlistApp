using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamWishlistApp.ViewModels {

    [QueryProperty(nameof(Friend), "Friend")]
    public class FriendViewModel : INotifyPropertyChanged {

        private Friend _friend;
        public Friend Friend {
            get => _friend;
            set {
                if (_friend != value) {
                    _friend = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
