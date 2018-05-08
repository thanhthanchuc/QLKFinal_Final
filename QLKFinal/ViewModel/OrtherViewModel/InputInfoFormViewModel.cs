using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKFinal.Models;
using QLKFinal.Models.MoreModels;

namespace QLKFinal.ViewModel.OrtherViewModel
{
    public class InputInfoFormViewModel
    {
        public InputInfo InputInfo { get; set; }
        public IEnumerable<Objectss> Objectsses { get; set; }
        public IEnumerable<Input> Inputs { get; set; }  
    }
}