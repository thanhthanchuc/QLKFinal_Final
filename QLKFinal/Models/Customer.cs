using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirt { get; set; }
        public string Email { get; set; }
        public string Adresss { get; set; }
        public string MoreInfo { get; set; }
        public DateTime? ContracDate { get; set; }

        public Suplier Suplier { get; set; }
        public int SuplierId { get; set; }
    }
}