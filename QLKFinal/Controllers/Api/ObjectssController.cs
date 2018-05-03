using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using QLKFinal.DTOS;
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
        public IEnumerable<ObjectssDto> GetObjectsses()
        {
            return _context.Objectsses.ToList().Select(Mapper.Map<Objectss, ObjectssDto>);
        }

        // GET / api/objectsses/1
        public IHttpActionResult GetObjectss(int id)
        {
            var objectss = _context.Objectsses.SingleOrDefault(o => o.Id == id);

            if (objectss == null)
                return NotFound();

            return Ok(Mapper.Map<Objectss, ObjectssDto>(objectss));
        }

        // POST /api/objectsses
        [HttpPost]
        public IHttpActionResult CreateObjectss(ObjectssDto objectssDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var objectss = Mapper.Map<ObjectssDto, Objectss>(objectssDto);
            _context.Objectsses.Add(objectss);
            _context.SaveChanges();

            objectssDto.Id = objectss.Id;

            return Created(new Uri(Request.RequestUri + "/" + objectss.Id), objectssDto);
        }

        //PUT/api/objectsses/1
        [HttpPut]
        public void UpdateObjectss(int id, ObjectssDto objectssDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var objectInDb = _context.Objectsses.SingleOrDefault(o => o.Id == id);

            if(objectInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<ObjectssDto, Objectss>(objectssDto, objectInDb);
            


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
