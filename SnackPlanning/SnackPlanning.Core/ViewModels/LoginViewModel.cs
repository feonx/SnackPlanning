using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

using MvvmCross.Core.ViewModels;

namespace SnackPlanning.Core.ViewModels
{
    public class LoginViewModel
        : BaseViewModel
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
            var isValid = ValidationHelper.Validate(new Dictionary<Helpers.ValidationProperty, string>
            {
                {
                    new Helpers.ValidationProperty
                    {

                        Name = nameof(Username),
                        Value = Username
                    },
                    "Gebruikersnaam is verplicht."
                },
                {
                    new Helpers.ValidationProperty
                    {

                        Name = nameof(Password),
                        Value = Password
                    },
                    "Wachtwoord is verplicht."
                }
            });

            if(isValid)
            {
                ShowLoading("Bezig met inloggen...");

                var login = new WebAPI.Login(Username, Password);

                if (await login.CheckCredentials())
                {
                    ShowMessage("De ingevoerde inloggegevens zijn correct.");
                }
                else
                {
                    ShowMessage("De ingevoerde inloggegevens zijn incorrect.");
                }

                HideLoading();
            }
        }

        public IMvxCommand RegisterCommand => new MvxCommand(Register);
        private void Register()
        {
            ShowViewModel<RegisterViewModel>();
        }


    }
}
