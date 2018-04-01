using System;
using MvvmCross.Core.ViewModels;
using MvvmValidation;
using SnackPlanning.Core.Common;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq.Expressions;

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
                },
                {
                    new Helpers.ValidationProperty
                    {
                        Name = nameof(Repassword),
                        Value = Repassword
                    }, 

                    "Wachtwoord is verplicht."
                }
            });

            if (!isValid)
            {
                return;
            }
             
            var isValidEmail = ValidationHelper.ValidateEmail(new Helpers.ValidationProperty
            {
                Name = nameof(Username),
                Value = Username
            }, "Het ingevoerde e-mail adres is niet juist.");

            if(!isValid)
            {
                return;
            }

        }

    }
}
