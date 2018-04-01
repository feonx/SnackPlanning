using System;
using MvvmValidation;
using System.Linq.Expressions;
using System.Collections.Generic;
using SnackPlanning.Core.Common;
using SnackPlanning.Core.ViewModels;
using System.Linq;
using System.Collections;

namespace SnackPlanning.Core.Helpers
{
    public class ValidationHelper
    {
        private MvvmValidation.ValidationHelper _validationHelper;
        private BaseViewModel _viewModel;

        public ValidationHelper(BaseViewModel baseViewModel)
        {
            _validationHelper = new MvvmValidation.ValidationHelper();
            _viewModel = baseViewModel;
        }

        private Common.ObservableDictionary<string, string> _validationErrors;
        public Common.ObservableDictionary<string, string> ValidationErrors
        {
            get => _validationErrors;
            set { _validationErrors = value; _viewModel.RaisePropertyChanged(() => ValidationErrors); }
        }

        public bool Validate(Dictionary<ValidationProperty, string> propertyAndErrors)
        {
            foreach (var propertyAndError in propertyAndErrors)
            {
                var property = propertyAndError.Key;
                var validationMessage = propertyAndError.Value;

                //_validationHelper.AddRequiredRule(() => property, validationMessage);
                _validationHelper.AddRule(property.Name, () => RuleResult.Assert(!string.IsNullOrWhiteSpace(property.Value), validationMessage));
            }

            var validationResult = _validationHelper.ValidateAll();

            ValidationErrors = validationResult.AsObservableDictionary();

            return validationResult.IsValid;
        }

        public bool ValidateEmail(ValidationProperty property, string validationMessage)
        {
            var isValid = System.Text.RegularExpressions.Regex.IsMatch(property.Value as string, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            _validationHelper.AddRule(property.Name, () => RuleResult.Assert(isValid, validationMessage));

            var validationResult = _validationHelper.ValidateAll();

            var validationMessages = validationResult.AsObservableDictionary();

            ValidationErrors = validationMessages;

            return validationResult.IsValid;
        }


       // public bool ValidateEquals(string )
    }

    public class ValidationProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }

    }
}
