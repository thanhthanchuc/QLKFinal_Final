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

        [Display(Name = "Tên")]
        public string DisplayName { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Addresss { get; set; }


        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public int PhoneNumber { get; set; }
        
        [Display(Name = "Thông tin khác")]
        public string MoreInfo { get; set; }

        [Display(Name = "Ngày gia nhập")]
        public DateTime? ContractDate { get; set; }
    }
}