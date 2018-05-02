using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKFinal.Models;

namespace QLKFinal.ViewModel
{
    public class ObjectFormViewModel
    {
        public IEnumerable<Unit> Units { get; set; }
        public Objectss Objectss { get; set; }
        public IEnumerable<Suplier> Supliers { get; set; }  
    }
}