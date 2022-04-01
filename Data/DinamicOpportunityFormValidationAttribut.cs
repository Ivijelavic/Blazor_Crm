using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CrmExpert.Data
{
    public class DinamicOpportunityFormValidationAttribut : ValidationAttribute
    {
        private readonly string _parentFildName;
        private readonly string _fildType;
        private readonly string[] _validationTypes;

        public DinamicOpportunityFormValidationAttribut(String parentFildName, string fildType, string[] validationTypes)
        {
            _parentFildName = parentFildName;
            _fildType = fildType;
            _validationTypes = validationTypes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance == null)
            {
                var parentFieldValueObject = validationContext.ObjectInstance.GetType()
                    .GetProperty(_parentFildName).GetValue(validationContext.ObjectInstance, null);

                string currentFieldValue = value != null ? value as string : string.Empty;
                string parentFieldValue = parentFieldValueObject != null ? parentFieldValueObject as string : string.Empty;

                if (string.IsNullOrEmpty(parentFieldValue) && parentFieldValue.ToLower() == _fildType.ToLower())
                {
                    if (string.IsNullOrEmpty(currentFieldValue) && _validationTypes.Any(_ => _.ToLower() == "required"))
                    {
                        return new ValidationResult($"{validationContext.DisplayName} is required", new[] { validationContext.MemberName });
                    }
                    else if (_validationTypes.Any(_ => _.ToLower() == "required"))
                    {
                        bool isEmail = Regex.IsMatch(currentFieldValue, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmail)
                        {
                            return new ValidationResult($"{validationContext.DisplayName} is not valid email", new[] { validationContext.MemberName });
                        }
                    }
                    else if (_validationTypes.Any(_ => _.ToLower() == "required"))
                    {
                        bool isPhone = Regex.IsMatch(currentFieldValue, @"\+?[0-9]{10}", RegexOptions.IgnoreCase);
                        if (!isPhone)
                        {
                            return new ValidationResult($"{validationContext.DisplayName} is not valid phone", new[] { validationContext.MemberName });
                        }
                    }
                    else if (_validationTypes.Any(_ => _.ToLower() == "required"))
                    {
                        bool isDecimal = Regex.IsMatch(currentFieldValue, @"^[0-9]{5}\.[0-9]{2}$", RegexOptions.IgnoreCase);
                        if (!isDecimal)
                        {
                            return new ValidationResult($"{ validationContext.DisplayName} is not valid decimal", new[] { validationContext.MemberName });
                        }
                    }
                    else if (_validationTypes.Any(_ => _.ToLower() == "required"))
                    {
                        bool isInteger = Regex.IsMatch(currentFieldValue, @"^[0 - 9]*$", RegexOptions.IgnoreCase);
                        if (!isInteger)
                        {
                            return new ValidationResult($"{ validationContext.DisplayName} is not valid integer", new[] { validationContext.MemberName });
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }


        public static bool ValidateDecimals(string input)
        {
            if (!decimal.TryParse(input, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, null, out _)) return false;
            var parts = input.Split('.');
            return parts.Length == 2 && parts[1].Length == 2;
        }
    }
}
