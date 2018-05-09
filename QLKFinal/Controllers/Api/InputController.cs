using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using QLKFinal.DTOS;
using QLKFinal.Models;
using QLKFinal.Models.MoreModels;

namespace QLKFinal.Controllers.Api
{
    public class InputController : ApiController
    {
        private ApplicationDbContext _context;

        public InputController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/input/
        public IHttpActionResult GetsInputs()
        {
            var inputDtos = _context.Inputs.ToList().Select(Mapper.Map<Input, InputDto>);

            return Ok(inputDtos);
        }

        //Get /api/input/1
        public IHttpActionResult GetInput(int id)
        {
            var input = _context.Inputs.SingleOrDefault(i => i.Id == id);

            if (input == null)
                return NotFound();
            return Ok(Mapper.Map<Input, InputDto>(input));
        }

        //POSt /api/inputs
        [HttpPost]
        public IHttpActionResult CreateInput(InputDto inputDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var input = Mapper.Map<InputDto, Input>(inputDto);
            _context.Inputs.Add(input);
            _context.SaveChanges();

            inputDto.Id = input.Id;
            return Created(new Uri(Request.RequestUri + "/" + input.Id), inputDto);
        }

        //PUT/api/input/1
        public IHttpActionResult UpdateInput(int id, InputDto inputDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inputInDb = _context.Supliers
                .SingleOrDefault(s => s.Id == id);

            if (inputInDb == null)
                return NotFound();

            Mapper.Map(inputDto, inputInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/inputs/1
        [HttpDelete]
        public IHttpActionResult DeleteInput(int id)
        {
            var inputInDb = _context.Inputs
                .SingleOrDefault(s => s.Id == id);

            if (inputInDb == null)
                return NotFound();

            _context.Inputs.Remove(inputInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
