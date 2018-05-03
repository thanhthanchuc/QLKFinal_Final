using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.Models.MoreModels
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if(customer.SuplierId==0||customer.SuplierId == 1)
                return ValidationResult.Success;

            if(customer.DateOfBirt == null)
                return new ValidationResult("Bạn không được bỏ chống trường này!");

            var age = DateTime.Today.Year - customer.DateOfBirt.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Khách hàng chưa đủ 18 tuổi. Vui lòng nhập lại!");
        }
    }
}