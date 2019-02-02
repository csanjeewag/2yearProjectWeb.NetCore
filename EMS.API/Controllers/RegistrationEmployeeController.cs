using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/RegistrationEmployee")]
    public class RegistrationEmployeeController : Controller
    {
        private readonly EMSContext _context;
        private readonly RegistrationEmployeeService _service;
        public RegistrationEmployeeController(EMSContext context)
        { 
            _context = context;
            _service = new RegistrationEmployeeService(_context);
        }

        [Produces("application/json")]
        [HttpGet("getEmployee/{id}")]
        //  [Authorize(Roles = "Administrator")]
        public IEnumerable<RegEmployee> GetEmployee(string id)
        {
            return _service.GetEmployee(id);

        }

        [Produces("application/json")]
        [HttpGet("getRegistrationAttribute/{id}")]
        public RegistrationAttribute GetRegistrationAttribute(int id)
        {
            return _service.GetRegistrationAttribute(id);
        }

        [HttpPost("addRegistrationAttribute")]
        public IActionResult AddRegistrationAttribute([FromForm]RegistrationAttribute even)
        {

            if (_service.AddRegistrationAttribute(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }


        [HttpPost("addEmployee")]
        public IActionResult AddEmployee([FromForm]RegEmployee even)
        {

            if (_service.AddEmployee(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }

        [HttpPost("updateRegistrationAttribute")]
        public IActionResult UpdateRegistrationAttribute([FromForm]RegistrationAttribute project)
        {

            if (_service.UpdateRegistrationAttribute(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [HttpGet("getEmp/{id}/{id2}")]
        public RegEmployee GetEmp(string id, string id2)
        {
            return _service.GetEmp(id, id2);
        }

        [HttpPost("deleteEmployee")]
        public IActionResult DeleteEmployee([FromForm]RegEmployee project)
        {

            if (_service.DeleteEmployee(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

    }
}
