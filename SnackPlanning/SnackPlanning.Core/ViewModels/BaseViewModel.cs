using System;
using MvvmCross.Core.ViewModels;
using MvvmValidation;
using SnackPlanning.Core.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using Acr.UserDialogs;

namespace SnackPlanning.Core.ViewModels
{
    public class BaseViewModel
        : MvxViewModel
    {
        private ObservableDictionary<string, string> _validationErrors;
        public ObservableDictionary<string, string> ValidationErrors
        {
            get => _validationErrors;
            set { _validationErrors = value; RaisePropertyChanged(() => ValidationErrors); }
        }

        public bool Validate(Dictionary<Expression<Func<object>>, string> propertyAndErrors)
        {
            var validationHelper = new ValidationHelper();

            foreach(var propertyAndError in propertyAndErrors)
            {
                var property = propertyAndError.Key;
                var validationMessage = propertyAndError.Value;

                validationHelper.AddRequiredRule(property, validationMessage);
            }

            var validationResult = validationHelper.ValidateAll();

            ValidationErrors = validationResult.AsObservableDictionary();

            return validationResult.IsValid;
        }

        public async void ShowMessage(string message)
        {
            await UserDialogs.Instance.AlertAsync(AlertConfig.DefaultOkText, "De ingevoerde inloggegevens zijn correct.");
        }
    }
}
