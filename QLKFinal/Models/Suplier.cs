using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Suplier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [Display(Name = "Tên")]
        public string DisplayName { get; set; }


        [Display(Name = "Địa chỉ")]
        public string Addresss { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email phải có dạng abc@manager.com")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public int PhoneNumber { get; set; }
        
        [Display(Name = "Thông tin khác")]
        public string MoreInfo { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [Display(Name = "Ngày gia nhập")]
        [DisplayFormat(DataFormatString = "{0:d/mm/yyyy}", 
            ApplyFormatInEditMode = true)]
        public DateTime? ContractDate { get; set; }
    }
}