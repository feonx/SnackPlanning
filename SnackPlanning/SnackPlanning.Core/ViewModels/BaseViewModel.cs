using System;
using MvvmCross.Core.ViewModels;
using Acr.UserDialogs;
using SnackPlanning.Core.Helpers;

namespace SnackPlanning.Core.ViewModels
{
    public class BaseViewModel
        : MvxViewModel
    {
        private ValidationHelper _validationHelper;
        public ValidationHelper ValidationHelper 
        {
            get 
            {
                return _validationHelper ?? new Helpers.ValidationHelper(this);
            }
        }

        public async void ShowMessage(string message)
        {
            await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn correct.");
        }

        public void ShowLoading(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();   
        }
    }

}
