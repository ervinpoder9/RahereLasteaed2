using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Core.Helpers {
    public class FutureDateAttribute : ValidationAttribute {
        public override bool IsValid(object? value) {
            if (value is DateTime dateValue) {
                return dateValue > DateTime.Today;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
            => $"{name} must be a future date.";
    }
}