using System.Net.Http.Headers;
using System.Text;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmValidation;
using SnackPlanning.Core.Common;


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
            if(Validate())
            {
                UserDialogs.Instance.ShowLoading("Bezig met inloggen...");

                var login = new WebAPI.Login(Username, Password);

                if (await login.CheckCredentials())
                {
                    await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn correct.");
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn incorrect.");
                }

                UserDialogs.Instance.HideLoading();
            }
        }

        public IMvxCommand RegisterCommand => new MvxCommand(Register);
        private void Register()
        {

        }

        private ObservableDictionary<string, string> _validationErrors;
        public ObservableDictionary<string, string> ValidationErrors
        {
            get => _validationErrors;
            set { _validationErrors = value; RaisePropertyChanged(() => ValidationErrors); }
        }

        private bool Validate()
        {
            var validationHelper = new ValidationHelper();
            validationHelper.AddRequiredRule(() => Username, "Gebruikersnaam is verplicht.");
            validationHelper.AddRequiredRule(() => Password, "Wachtwoord is verplicht.");

            var validationResult = validationHelper.ValidateAll();

            ValidationErrors = validationResult.AsObservableDictionary();

            return validationResult.IsValid;
        }
    }
}
