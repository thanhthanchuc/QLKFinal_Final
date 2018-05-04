using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKFinal.DTOS
{
    public class UnitDto
    {
        public int Id { get; set; }

        [Required] public string DisplayName { get; set; }
    }
}