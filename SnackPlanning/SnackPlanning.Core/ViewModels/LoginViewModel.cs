using System.Net.Http.Headers;
using System.Text;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;


namespace SnackPlanning.Core.ViewModels
{
    public class LoginViewModel
        : MvxViewModel
    {
        

        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public IMvxCommand LoginCommand => new MvxCommand(Login);
        private async void Login()
        {
            UserDialogs.Instance.ShowLoading("Bezig met inloggen...");

            var login = new WebAPI.Login(Username, Password);

            if(await login.CheckCredentials())
            {
                await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn correct.");
            }
            else
            {
                UserDialogs.Instance.HideLoading();
                await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn incorrect.");
            }


        }

        public IMvxCommand RegisterCommand => new MvxCommand(Register);
        private void Register()
        {

        }
    }
}
