using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKFinal.Models
{
    public class Suplier
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Addresss { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        
        public string MoreInfo { get; set; }
        public DateTime? ContractDate { get; set; }
    }
}