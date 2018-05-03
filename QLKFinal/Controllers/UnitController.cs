using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using QLKFinal.ViewModel.OrtherViewModel;

namespace QLKFinal.Controllers
{
    public class UnitController : Controller
    {
        private ApplicationDbContext _context;

        public UnitController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Save(Unit unit)
        {
            if (unit.Id == 0)
                _context.Units.Add(unit);
            else
            {
                var unitInDb = _context.Units.Single(u => u.Id == unit.Id);
                unitInDb.DisplayName = unit.DisplayName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Unit");
        }

        public ActionResult Index()
        {
            var unit = _context.Units.ToList();
            return View(unit);
        }

        public ActionResult New()
        {
            var viewModel = new UnitFormViewModel();
            return View("UnitForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var unit = _context.Units.SingleOrDefault(u => u.Id == id);
            if (unit == null)
                return HttpNotFound();

            var viewModel = new UnitFormViewModel
            {
                Unit = unit
            };

            return View("UnitForm", viewModel);
        }
    }
}