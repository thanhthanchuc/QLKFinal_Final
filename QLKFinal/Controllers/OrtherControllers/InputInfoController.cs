using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using System.Data.Entity;
using QLKFinal.Models.MoreModels;
using QLKFinal.ViewModel.OrtherViewModel;

namespace QLKFinal.Controllers.OrtherControllers
{
    public class InputInfoController : Controller
    {
        private ApplicationDbContext _context;

        public InputInfoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var objectss = _context.Objectsses
                .Include(s => s.Suplier)
                .Include(u => u.Unit)
                .ToList();

            var input = _context.Inputs.ToList();
            var viewModel = new InputInfoFormViewModel
            {
                InputInfo = new InputInfo(),
                Objectsses = objectss,
                Inputs = input
            };

            return View("InputInfoForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(InputInfo inputinfo)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InputInfoFormViewModel
                {
                    InputInfo = inputinfo,
                    Inputs = _context.Inputs.ToList(),
                    Objectsses = _context.Objectsses
                        .Include(u => u.Unit)
                        .Include(s => s.Suplier)
                        .ToList(),

                };
                return View("InputInfoForm", viewModel);
            }

            if (inputinfo.Id == 0)
                _context.InputInfos.Add(inputinfo);
            else
            {
                var inputinfoInDb = _context.InputInfos.Single(i => i.Id == inputinfo.Id);
                inputinfoInDb.Count = inputinfo.Count;
                inputinfoInDb.InputId = inputinfo.InputId;
                inputinfoInDb.InputPrice = inputinfo.InputPrice;
                inputinfoInDb.OutputPrice = inputinfo.OutputPrice;
                inputinfoInDb.ObjectssId = inputinfo.ObjectssId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "InputInfo");
        }

        // GET: InputInfo
        public ActionResult Index()
        {
            var item = _context.InputInfos.Include(i => i.Input).Include(o => o.Objectss).ToList();
            return View(item);
        }
    }
}