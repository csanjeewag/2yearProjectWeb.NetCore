using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Contact = EMS.Data.Models.Contact;
namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/contact")]
    public class ContactController:Controller
    {
        private readonly EMSContext _context;
        private readonly ContactService _service;
        private readonly TaskInformationService _serviceinfo;

        public ContactController(EMSContext context)
        {
            _context = context;
            _service = new ContactService(_context);
            _serviceinfo = new TaskInformationService(_context);
        }

        [Produces("application/json")]
        [HttpGet("getalltypes")]
        public IActionResult GetContactTypes()
        {


            var result = _service.GetContactTypes();
            return Ok(result);


        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addcontacttype")]
        public IActionResult AddContactType([FromBody]Contact c)
        {

            if (_service.AddContactType(c))
            {

                return Ok(c);
            }
            else
            {
                return BadRequest("error");
            }
        }

        [HttpPost("updatecontacttype")]
        public IActionResult UpdateContactType([FromForm]Contact c)
        {

            if (_service.UpdateContactType(c)) 
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [HttpGet("deactive/{id}")]
        public Boolean DeleteContactType(int id)
        {
            return _service.DeleteContactType(id);
        }



        /// <summary>
        /// get all contacts for given type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getallfortype/{id}")]
        public IEnumerable<ContactDetails> GetAllForType(int id)
        {
            return _service.GetAllForType(id);

        }



        [HttpPost("addcontactdetailnormally")]
        public IActionResult AddContactDetailNormally([FromForm]ContactDetails c)
        {

            if (_service.AddContactDetailNormally(c))
            {

                return Ok(c);
            }
            else
            {
                return BadRequest("error");
            }
        }
                                    
       

        


        [HttpPost("updatecontactdetail")]
        public IActionResult UpdateContactDetail([FromForm]ContactDetails c)
        {

            if (_service.UpdateContactDetail(c))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [HttpGet("deactivedetail/{id}")]
        public Boolean DeleteContactDetail(int id)
        {
            return _service.DeleteContactDetail(id);
        }


        [Produces("application/json")]
        [HttpGet("/{id}")]

        public IEnumerable<ContactDetails> GetContactDetailsByTaskId(int id)
        {
            return _service.GetContactDetailsByTaskId(id);

        }




    }
}
