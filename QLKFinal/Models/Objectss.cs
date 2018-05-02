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

        [Display(Name = "Tên vật tư")]
        public string DisplayName { get; set; }

        [Display(Name = "Số lượng")]
        public int Count { get; set; }

        [Display(Name = "Ngày thêm")] public DateTime? DateAdded { get; set; }

        public Suplier Suplier { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int SuplierId { get; set; }

        public Unit Unit { get; set; }

        [Display(Name = "Đơn vị")]
        public int UnitId { get; set; }

    }
}