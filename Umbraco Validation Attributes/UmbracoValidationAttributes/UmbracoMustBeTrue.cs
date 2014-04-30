﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoMustBeTrue : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Convert the value to a bool & check it's true
            if ((bool)value)
            {
                //All good :)
                return ValidationResult.Success;
            }

            //Get the error message to return
            var error = FormatErrorMessage(validationContext.DisplayName);

            //Return error
            return new ValidationResult(error);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage    = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType  = "mustbetrue"
            };

            yield return rule;
        }

    }
}
