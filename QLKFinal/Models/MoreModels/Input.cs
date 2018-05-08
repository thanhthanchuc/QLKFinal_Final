using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.Models.MoreModels
{
    public class Input
    {
        public int Id { get; set; }

        [Display(Name = "Ngày tạo phiếu")]
        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        public DateTime? DateAdded { get; set; }
    }
}