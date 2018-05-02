﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using QLKFinal.ViewModel;

namespace QLKFinal.Controllers
{
    public class SuplierController : Controller
    {
        private ApplicationDbContext _context;

        public SuplierController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new SuplierFormViewModel
            {
            };
            return View("SuplierForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Suplier suplier)
        {
            if (suplier.Id == 0)
                _context.Supliers.Add(suplier);
            else
            {
                var suplierInDb = _context.Supliers.Single(s => s.Id == suplier.Id);
                suplierInDb.DisplayName = suplier.DisplayName;
                suplierInDb.Addresss = suplier.Addresss;
                suplierInDb.ContractDate = suplier.ContractDate;
                suplierInDb.Email = suplier.Email;
                suplierInDb.MoreInfo = suplier.MoreInfo;
                suplierInDb.PhoneNumber = suplier.PhoneNumber;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Suplier");
        }


        // GET: Suplier
        public ActionResult Index()
        {
            var suplier = _context.Supliers.ToList();
            return View(suplier);
        }

        public ActionResult Details(int id)
        {
            var suplier = _context.Supliers.SingleOrDefault(c => c.Id == id);

            if (suplier == null)
                return HttpNotFound();

            return View(suplier);
        }

        public ActionResult Edit(int id)
        {
            var suplier = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if (suplier == null)
                return HttpNotFound();

            var viewModel = new SuplierFormViewModel
            {
                Suplier = suplier
            };

            return View("SuplierForm", viewModel);
        }
    }
}