using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.DTOS
{
    public class SuplierDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        public string DisplayName { get; set; }


        public string Addresss { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        public string Email { get; set; }

        [Phone]
        public int PhoneNumber { get; set; }

        public string MoreInfo { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        public DateTime? ContractDate { get; set; }
    }
}