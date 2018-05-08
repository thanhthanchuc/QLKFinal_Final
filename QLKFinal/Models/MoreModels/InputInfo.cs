using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace QLKFinal.Models.MoreModels
{
    public class InputInfo
    {
        public int Id { get; set; }

        public int? Count { get; set; }

        public float InputPrice { get; set; }

        public float OutputPrice { get; set; }

        public string Status { get; set; }

        public Objectss Objectss { get; set; }

        public int ObjectssId { get; set; }

        public Input Input { get; set; }

        public int InputId { get; set; }
    }
}