﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Data;
using Solid.Service.Services;
using System.Net;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _doctorService.GetDoctorAsync());
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doc = _doctorService.GetByIdAsync(id);
            if (doc is null)
            {
                return NotFound();
            }
            return Ok(await doc);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Doctor doctor)
        {
           return Ok(await _doctorService.AddDoctorAsync(doctor));
        }


        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Doctor doctor)
        {
           return Ok(await _doctorService.UpdateDoctorAsync(id, doctor));
            
        }


        //// DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
