using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [StringLength(255)]
        [Display(Name = "Đơn vị")]
        public string DisplayName { get; set; }
    }
}