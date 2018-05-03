using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Objectss
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [StringLength(255)]
        [Display(Name = "Tên vật tư")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [Display(Name = "Số lượng")]
        public int? Count { get; set; }

        [Required(ErrorMessage = "Bạn không được bỏ chống trường này!")]
        [Display(Name = "Ngày thêm")]
        public DateTime? DateAdded { get; set; }

        public Suplier Suplier { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà cung cấp!")]
        [Display(Name = "Nhà cung cấp")]
        public int SuplierId { get; set; }

        [Required]
        [Range(1,Int32.MaxValue)]
        public Unit Unit { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn đơn vị!")]
        [Display(Name = "Đơn vị")]
        public int UnitId { get; set; }

    }
}