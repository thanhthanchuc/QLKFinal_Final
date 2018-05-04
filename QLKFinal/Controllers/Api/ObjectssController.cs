using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using QLKFinal.DTOS;
using QLKFinal.Models;
using System.Data.Entity;

namespace QLKFinal.Controllers.Api
{
    public class ObjectssController : ApiController
    {
        private ApplicationDbContext _context;

        public ObjectssController()
        {
            _context = new ApplicationDbContext();
        }



        // GET /api/objectsses : API - Application Program Interface
        public IHttpActionResult GetObjectsses()
        {
            var objectDtos = _context.Objectsses
                .Include(u => u.Unit)
                .Include(s => s.Suplier)
                .ToList()
                .Select(Mapper.Map<Objectss, ObjectssDto>);

            return Ok(objectDtos);
        }

        // GET / api/objectsses/1
        public IHttpActionResult GetObjectss(int id)
        {
            var objectss = _context.Objectsses
                .SingleOrDefault(o => o.Id == id);

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
        public IHttpActionResult UpdateObjectss(int id, ObjectssDto objectssDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var objectInDb = _context.Objectsses
                .SingleOrDefault(o => o.Id == id);

            if (objectInDb == null)
                return NotFound();

            Mapper.Map(objectssDto, objectInDb);
            
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/objectss/1
        [HttpDelete]
        public IHttpActionResult DeleteObjectss(int id)
        {
            var objectInDb = _context.Objectsses
                .SingleOrDefault(o => o.Id == id);

            if (objectInDb == null)
                return NotFound();

            _context.Objectsses.Remove(objectInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
