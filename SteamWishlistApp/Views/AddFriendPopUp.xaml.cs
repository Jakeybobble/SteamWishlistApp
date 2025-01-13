using Mopups.Services;
using Mopups.Pages;
using System;
using System.Threading.Tasks;

namespace SteamWishlistApp.Views
{
    public partial class AddFriendPopUp : PopupPage // Change this line to PopupPage
    {
        private TaskCompletionSource<string> _taskCompletionSource;

        public AddFriendPopUp(TaskCompletionSource<string> taskCompletionSource)
        {
            InitializeComponent();
            _taskCompletionSource = taskCompletionSource;
        }

        private void OnOk(object sender, EventArgs e)
        {
            _taskCompletionSource.SetResult(FriendNameEntry.Text); // Get the entered name
            MopupService.Instance.PopAsync();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            _taskCompletionSource.SetResult(null); // Cancel action
            MopupService.Instance.PopAsync();
        }
    }
}
