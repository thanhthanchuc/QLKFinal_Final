﻿using System;
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
    public class SuplierController : ApiController
    {
        private ApplicationDbContext _context;

        public SuplierController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetsSupliers()
        {
            var suplierDtos = _context.Supliers
                .ToList()
                .Select(Mapper.Map<Suplier, SuplierDto>);

            return Ok(suplierDtos);

        }

        // GET/api/suplier/1
        public IHttpActionResult GetSuplier(int id)
        {
            var suplier = _context.Supliers
                .SingleOrDefault(s => s.Id == id);

            if (suplier == null)
                return NotFound();

            return Ok(Mapper.Map<Suplier, SuplierDto>(suplier));
        }

        //POST/api/supliers
        [HttpPost]
        public IHttpActionResult CreateSuplier(SuplierDto suplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var suplier = Mapper.Map<SuplierDto, Suplier>(suplierDto);
            _context.Supliers.Add(suplier);
            _context.SaveChanges();

            suplierDto.Id = suplier.Id;
            return Created(new Uri(Request.RequestUri + "/" + suplier.Id), suplierDto);
        }

        //PUT/api/supliers/1
        public IHttpActionResult UpdateSuplier(int id, SuplierDto suplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var suplierInDb = _context.Supliers
                .SingleOrDefault(s => s.Id == id);

            if (suplierInDb == null)
                return NotFound();

            Mapper.Map(suplierDto, suplierInDb);
            
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/supliers/1
        [HttpDelete]
        public IHttpActionResult DeleteSuplier(int id)
        {
            var suplierInDb = _context.Supliers
                .SingleOrDefault(s => s.Id == id);

            if (suplierInDb == null)
                return NotFound();

            _context.Supliers.Remove(suplierInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
