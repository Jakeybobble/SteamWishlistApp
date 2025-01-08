﻿using SteamWishlistApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamWishlistApp.ViewModel {
    public class BaseViewModel : INotifyPropertyChanged {

        private ObservableCollection<Friend> _friends = new ObservableCollection<Friend>();
        public ObservableCollection<Friend> Friends {
            get => _friends;
            set {
                _friends = value;
                OnPropertyChanged(nameof(Friends));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
