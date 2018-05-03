using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QLKFinal.Models.MoreModels;

namespace QLKFinal.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [StringLength(255)]
        [Display(Name = "Tên khách hàng")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [Display(Name = "Số điện thoại liên lạc")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirt { get; set; }

        public string Email { get; set; }

        public string Adresss { get; set; }

        public string MoreInfo { get; set; }

        
        [Min18YearsIfAMember]
        public DateTime? ContracDate { get; set; }

        public Suplier Suplier { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà cung cấp!")]
        [Display(Name = "Thuộc nhà cung cấp")]
        public int SuplierId { get; set; }
    }
}