using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using QLKFinal.ViewModel;
using System.Data.Entity;
using System.Web.Security;

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

        [Authorize(Roles = "admin")]
        public ActionResult New()
        {
            var units = _context.Units.ToList();
            var suplier = _context.Supliers.ToList();
            var viewModel = new ObjectFormViewModel
            {
                Objectss = new Objectss(),
                Units = units,
                Supliers = suplier
            };

            return View("ObjectForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//CSRF: Cross-sire Request Forgery
        public ActionResult Save(Objectss objectss)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ObjectFormViewModel
                {
                    Objectss = objectss,
                    Units = _context.Units.ToList(),
                    Supliers = _context.Supliers.ToList()
                };
                return View("ObjectForm", viewModel);
            }
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
            var item = _context.Objectsses
                .Include(u => u.Unit)
                .Include(s => s.Suplier)
                .ToList();
            if (User.IsInRole("admin"))
                return View("Index", item);

            return View("Index - Copy", item);
        }

        //public ActionResult OfSuplier()
        //{
        //    var suplier = _context.Supliers.ToList();
        //    var item = from s in _context.Objectsses.Include(u=>u.Unit).Include(s=>s.Suplier)
        //        where s.SuplierId == suplier.Id
        //    return View(item);
        //}

        public ActionResult Details(int id)
        {
            var item = _context.Objectsses
                .Include(u => u.Suplier).Include(u => u.Unit)
                .SingleOrDefault(o => o.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [Authorize(Roles = "admin")]
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

        public ActionResult PdfResult()
        {
            return View("ObjectForm");
        }
    }
}