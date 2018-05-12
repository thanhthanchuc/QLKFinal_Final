using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKFinal.Models;
using QLKFinal.Models.MoreModels;
using QLKFinal.ViewModel.OrtherViewModel;

namespace QLKFinal.Controllers
{
    public class InputController : Controller
    {
        private ApplicationDbContext _context;

        public InputController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Input
        public ActionResult Index()
        {
            var input = _context.Inputs.ToList();

            if (User.IsInRole("admin"))
                return View("Index", input);

            return View("Index - Copy", input);
        }

        [Authorize(Roles = "admin")]
        public ActionResult New()
        {
            var viewModel = new InputFormViewModel
            {
                Input = new Input()
            };

            return View("InputForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Input input)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InputFormViewModel
                {
                    Input = input
                };
                return View("InputForm", viewModel);
            }

            if (input.Id == 0)
                _context.Inputs.Add(input);
            else
            {
                var inputInDb = _context.Inputs.Single(i => i.Id == input.Id);
                inputInDb.DateAdded = input.DateAdded;
                inputInDb.DisplayName = input.DisplayName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Input");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var input = _context.Inputs.SingleOrDefault(i => i.Id == id);

            if (input == null)
                return HttpNotFound();

            var viewModel = new InputFormViewModel
            {
                Input = input
            };

            return View("InputForm", viewModel);
        }

        
    }
}