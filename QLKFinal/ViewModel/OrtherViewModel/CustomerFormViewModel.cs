using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKFinal.Models;

namespace QLKFinal.ViewModel.OrtherViewModel
{
    public class CustomerFormViewModel
    {
        public Suplier Suplier { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
    }
}