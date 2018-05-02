using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Objectss
    {
        public char Id { get; set; }
        public string DisplayName { get; set; }
        public int Count { get; set; }
        public DateTime? DateAdded { get; set; }

        public Suplier Suplier { get; set; }

        public int SuplierId { get; set; }

        public Unit Unit { get; set; }

        public int UnitId { get; set; }

    }
}