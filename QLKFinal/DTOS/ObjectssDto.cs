using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QLKFinal.Models;

namespace QLKFinal.DTOS
{
    public class ObjectssDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DisplayName { get; set; }

        [Required]
        public int? Count { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }

        public SuplierDto Suplier { get; set; }


        public Unit Unit { get; set; }

    }
}