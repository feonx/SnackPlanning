using System;
using MvvmCross.Core.ViewModels;
using MvvmValidation;
using SnackPlanning.Core.Common;

namespace SnackPlanning.Core.ViewModels
{
    public class RegisterViewModel
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

        private string _repassword = string.Empty;
        public string Repassword
        {
            get { return _repassword; }
            set { SetProperty(ref _repassword, value); }
        }

        public IMvxCommand RegisterCommand => new MvxCommand(Register);
        private async void Register()
        {
            var isValid = Validate(new System.Collections.Generic.Dictionary<System.Linq.Expressions.Expression<System.Func<object>>, string>
            {
                { () => Username, "Gebruikersnaam is verplicht." },
                { () => Password, "Wachtwoord is verplicht." },
                { () => Repassword, "Wachtwoord is verplicht." },
            });

            if(isValid)
            {
                
            }
        }

    }
}
