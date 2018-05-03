using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKFinal.Models;

namespace QLKFinal.Controllers.Api
{
    public class SuplierController : ApiController
    {
        private ApplicationDbContext _context;

        public SuplierController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Suplier> GetsSupliers()
        {
            return _context.Supliers.ToList();

        }

        // GET/api/suplier/1
        public Suplier GetSuplier(int id)
        {
            var suplier = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if(suplier==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return suplier;
        }

        //POST/api/supliers
        [HttpPost]
        public Suplier CreateSuplier(Suplier suplier)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Supliers.Add(suplier);
            _context.SaveChanges();

            return suplier;
        }

        //PUT/api/supliers/1
        public void UpdateSuplier(int id, Suplier suplier)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var suplierInDb = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if(suplierInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            suplierInDb.DisplayName = suplier.DisplayName;
            suplierInDb.Addresss = suplier.Addresss;
            suplierInDb.ContractDate = suplier.ContractDate;
            suplierInDb.Email = suplier.Email;
            suplierInDb.MoreInfo = suplier.MoreInfo;
            suplierInDb.PhoneNumber = suplier.PhoneNumber;

            _context.SaveChanges();
        }

        //DELETE /api/supliers/1
        [HttpDelete]
        public void DeleteSuplier(int id)
        {
            var suplierInDb = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if (suplierInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Supliers.Remove(suplierInDb);
            _context.SaveChanges();
        }
    }
}
