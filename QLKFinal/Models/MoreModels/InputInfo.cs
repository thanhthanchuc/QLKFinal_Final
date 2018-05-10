using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace QLKFinal.Models.MoreModels
{
    public class InputInfo
    {
        public int Id { get; set; }

        [Display(Name = "Số lượng")]
        public int? Count { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Display(Name = "Giá nhập vào")]
        public float InputPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Giá bán ra")]
        public float OutputPrice { get; set; }

        [Display(Name = "Tình trạng")]
        public string Status { get; set; }

        public Objectss Objectss { get; set; }

        [Display(Name = "Vật phẩm")]
        public int ObjectssId { get; set; }

        public Input Input { get; set; }

        [Display(Name = "Phiếu nhập")]
        public int InputId { get; set; }
    }
}