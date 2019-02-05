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
    [Route("api/Notification")]
    public class NotificationController : Controller
    {

        private readonly EMSContext _context;
        private readonly NotificationService _service;
       

        public NotificationController(EMSContext context)
        {
            _context = context;
            _service = new NotificationService(_context);
            
        }


        [HttpGet("getnotification/{id}")]
        public IActionResult ViewNotifation(int id)
        {

            var result = _service.ViewNotifation(id).OrderByDescending(c => c.Id).Take(15).ToList();
            var count = result.Select(x => x.Id).Count();
            result[0].count = count;
            if (result != null)
            {
                
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("removenotification/{id}/{empId}")]
        public IActionResult RemoveNotification(int id,int empId)
        {
            
            var result= _service.RemoveNotification(id,empId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("addspcialnotification")]
        public IActionResult SpecialaNotification([FromForm]Notification input)
        {
            var result= _service.SpecialaNotification(input);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}