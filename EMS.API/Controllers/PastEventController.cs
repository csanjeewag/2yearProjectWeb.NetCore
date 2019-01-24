using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



using System.IdentityModel.Tokens.Jwt;
using System.IO;

using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;


namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PastEvent")]
    public class PastEventController : Controller
    {
        private readonly EMSContext _context;
        private readonly PastEventService _service;
        public PastEventController(EMSContext context)
        {
            _context = context;
            _service = new PastEventService(_context);
        }

        [HttpPost("addimage")]
        public IActionResult AddImage([FromForm]GetEventImage image)
        {
            try
            {
                var result = new List<String>();
                if (image.Image != null)
                {
                    result = AddFiles.AddImages(image.Image, image.EventId.ToString());

                }

                EventImages eventimage = new EventImages();
                
                eventimage.EventId = image.EventId;
                eventimage.Caption = image.Caption;
                eventimage.Description = image.Description;
                eventimage.EmployeeId = image.Author;

                var test = _service.AddImage(eventimage,result);
                if (test) { return Ok(); }
                else { return BadRequest(); }
                
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("getimages/{id}")]
        public IActionResult GetImages(int id)
        {
            try {
                var text = _service.GetImages(id);
                return Ok(text);
            }
            catch { return BadRequest(); }
            
        }

        [HttpGet("getevents")]
        public IActionResult GetAllEvent()
        {
            
            try
            {
                var text = _service.GetAllEvent();
                return Ok(text);
            }
            catch { return BadRequest(); }
        }


        [HttpGet("getevent/{id}")]
        public IActionResult GetEvent(int id)
        {

            try
            {
                var text = _service.GetEvent(id);
                return Ok(text);
            }
            catch { return BadRequest(); }
        }


        [HttpPost("comment")]
        public IActionResult Comment ([FromForm]Comment cmt)
        {

            if (_service.AddComment(cmt))
            {

                return Ok(cmt);
            }
            else
            {
                return BadRequest("error");
            }

        }

        [HttpGet("getcomment")]
        public IActionResult GetComments()
        {


            var result = _service.GetComments();
            return Ok(result);


        }

    }
}

