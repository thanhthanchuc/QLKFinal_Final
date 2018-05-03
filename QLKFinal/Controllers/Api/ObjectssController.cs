using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKFinal.Models;

namespace QLKFinal.Controllers.Api
{
    public class ObjectssController : ApiController
    {
        private ApplicationDbContext _context;

        public ObjectssController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/objectsses
        public IEnumerable<Objectss> GetObjectsses()
        {
            return _context.Objectsses.ToList();
        }

        // GET / api/objectsses/1
        public Objectss GetObjectss(int id)
        {
            var objectss = _context.Objectsses.SingleOrDefault(o => o.Id == id);

            if(objectss==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return objectss;
        }

        // POST /api/objectsses
        [HttpPost]
        public Objectss CreateObjectss(Objectss objectss)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Objectsses.Add(objectss);
            _context.SaveChanges();

            return objectss;
        }

        //PUT/api/objectsses/1
        [HttpPut]
        public void UpdateObjectss(int id, Objectss objectss)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var objectInDb = _context.Objectsses.SingleOrDefault(o => o.Id == id);

            if(objectInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            objectInDb.DisplayName = objectss.DisplayName;
            objectInDb.Count = objectss.Count;
            objectInDb.DateAdded = objectss.DateAdded;
            objectInDb.SuplierId = objectss.SuplierId;
            objectInDb.UnitId = objectss.UnitId;

            _context.SaveChanges();
        }

        //DELETE /api/objectss/1
        [HttpDelete]
        public void DeleteObjectss(int id)
        {
            var objectInDb = _context.Objectsses.SingleOrDefault(o => o.Id == id);

            if (objectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Objectsses.Remove(objectInDb);
            _context.SaveChanges();
        }
    }
}
