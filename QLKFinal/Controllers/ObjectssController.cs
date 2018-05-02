using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using QLKFinal.ViewModel;
using System.Data.Entity;

namespace QLKFinal.Controllers
{
    public class ObjectssController : Controller
    {
        private ApplicationDbContext _context;

        public ObjectssController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var units = _context.Units.ToList();
            var suplier = _context.Supliers.ToList();
            var viewModel = new ObjectFormViewModel
            {
                Units = units,
                Supliers = suplier
            };

            return View("ObjectForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Objectss objectss)
        {
            if (objectss.Id == 0)
                _context.Objectsses.Add(objectss);
            else
            {
                var objectInDb = _context.Objectsses.Single(o => o.Id == objectss.Id);
                objectInDb.DisplayName = objectss.DisplayName;
                objectInDb.DateAdded = objectss.DateAdded;
                objectInDb.Count = objectss.Count;
                objectInDb.SuplierId = objectss.SuplierId;
                objectInDb.UnitId = objectss.UnitId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Objectss");
        }

        public ActionResult Index()
        {
            var item = _context.Objectsses.Include(s => s.Suplier).Include(u => u.Unit).ToList();
            return View(item);
        }

        public ActionResult Details(int id)
        {
            var item = _context.Objectsses.Include(u => u.Suplier).Include(u => u.Unit)
                .SingleOrDefault(o => o.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Objectsses.SingleOrDefault(o => o.Id == id);
            if (item == null)
                return HttpNotFound();

            var viewModel = new ObjectFormViewModel
            {
                Objectss = item,
                Units = _context.Units.ToList(),
                Supliers = _context.Supliers.ToList()
            };

            return View("ObjectForm", viewModel);
        }
    }
}