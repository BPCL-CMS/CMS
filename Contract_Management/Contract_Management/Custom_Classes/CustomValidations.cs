using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contract_Management.Custom_Classes
{
    public class CustomValidations
    {
        public string EmployeeCode { get; set; }
        public bool IsCreateUsecase { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsCreateUsecase && string.IsNullOrWhiteSpace(EmployeeCode))
            {
                yield return new ValidationResult(
                    "EmployeeCode is required for create usecase",
                    new[] { "EmployeeCode" }
                );
            }
        }
    }
}