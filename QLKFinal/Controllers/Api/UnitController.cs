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
    public class UnitController : ApiController
    {
        private ApplicationDbContext _context;

        public UnitController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetUnits()
        {
            var unitDtos = _context.Units
                .ToList()
                .Select(Mapper.Map<Unit, UnitDto>);

            return Ok(unitDtos);
        }

        //GET /api/unit/1
        public IHttpActionResult GetUnit(int id)
        {
            var unit = _context.Units.SingleOrDefault(u => u.Id == id);

            if (unit == null)
                return NotFound();

            return Ok(Mapper.Map<Unit, UnitDto>(unit));
        }

        //POST /api/units
        [HttpPost]
        public IHttpActionResult CreateUnit(UnitDto unitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var unit = Mapper.Map<UnitDto, Unit>(unitDto);
            _context.Units.Add(unit);
            _context.SaveChanges();

            unitDto.Id = unit.Id;
            return Created(new Uri(Request.RequestUri + "/" + unit.Id), unitDto);
        }

        //PUT /api/units/1
        public IHttpActionResult UpdateUnit(int id, UnitDto unitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var unitInDb = _context.Units.SingleOrDefault(u => u.Id == id);

            if (unitInDb == null)
                return NotFound();

            Mapper.Map(unitDto, unitInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/units/1
        [HttpDelete]
        public IHttpActionResult DeleteUnit(int id)
        {
            var unitInDb = _context.Units.SingleOrDefault(u => u.Id == id);

            if (unitInDb == null)
                return NotFound();

            _context.Units.Remove(unitInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
