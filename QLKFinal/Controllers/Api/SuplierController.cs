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
    public class SuplierController : ApiController
    {
        private ApplicationDbContext _context;

        public SuplierController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<SuplierDto> GetsSupliers()
        {
            return _context.Supliers.ToList().Select(Mapper.Map<Suplier, SuplierDto>);

        }

        // GET/api/suplier/1
        public SuplierDto GetSuplier(int id)
        {
            var suplier = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if(suplier==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Suplier, SuplierDto>(suplier);
        }

        //POST/api/supliers
        [HttpPost]
        public SuplierDto CreateSuplier(SuplierDto suplierDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var suplier = Mapper.Map<SuplierDto, Suplier>(suplierDto);
            _context.Supliers.Add(suplier);
            _context.SaveChanges();

            suplierDto.Id = suplier.Id;
            return suplierDto;
        }

        //PUT/api/supliers/1
        public void UpdateSuplier(int id, SuplierDto suplierDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var suplierInDb = _context.Supliers.SingleOrDefault(s => s.Id == id);

            if(suplierInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(suplierDto, suplierInDb);
            
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
