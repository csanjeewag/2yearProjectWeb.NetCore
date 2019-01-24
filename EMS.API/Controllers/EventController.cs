using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {

        private readonly EMSContext _context;
        private readonly EventService _service;
        public EventController(EMSContext context)
        {
            _context = context;
            _service = new EventService(_context);
        }


        [HttpPost("createevent")]
        public IActionResult CreateEvent([FromForm]Event even)
        {
            string res = "";
            if (even.EventImage != null)
            {
                // add profile picture 
                res = AddFiles.AddImage(even.EventImage, even.EventTitle);
                even.EventImage = null;


            }
            even.EventImageUrl = res;

            if (_service.AddEvent(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //method for create an event

        [HttpPost("selectAttributes")]
        public IActionResult SelectAttributes([FromForm]EventAttribute even)
        {

            if (_service.SelectAttributes(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }


        [HttpPost("updateevent")]
        public IActionResult UpdateProject([FromForm]Event even)
        {

            string res = "";
            if (even.EventImage != null)
            {
                // add profile picture 
                res = AddFiles.AddImage(even.EventImage, even.EventTitle);
                even.EventImage = null;
                even.EventImageUrl = res;

            }


            if (_service.UpdateEvent(even))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }
        [HttpPost("upselectAttributes")]
        public IActionResult UpdateAttribute([FromForm]EventAttribute project)
        {

            if (_service.UpdateAttribute(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }



        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public Event GetEventDetails(string id)
        {
            return _service.GetEventDetails(id);
        }
        //method for get details of a selected event



        [Produces("application/json")]
        [HttpGet("getatribute/{id}")]
        public EventAttribute GetAttributes(int id)
        {
            return _service.GetAttributes(id);
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForOneDayTrip")]
        public IActionResult RegisterForOneDayTrip([FromBody]OneDayTripRegistrant reg)
        {

            if (_service.RegisterForOneDayTrip(reg))
            {
                return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for single day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForTwoDayTrip")]
        public IActionResult RegisterForTwoDayTrip([FromBody]TwoDayTripRegistrants reg)
        {

            if (_service.RegisterForTwoDayTrip(reg))
            {

                return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for multiple day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("v")]
        public IActionResult ViewUpComingEvents()
        {

            var res = _service.ViewUpComingEvents();

            try { return Ok(res); } catch { return BadRequest("error get departments!"); }
        }
        //get details of up coming events filter by startdate


        [HttpPost("addfrontpage")]
        public IActionResult AddFrontPage([FromForm]FrontPage page)
        {
            try
            {
                var test = _service.AddFrontPage(page);
                if (test) { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet("getfrontpage/{id}")]
        public IActionResult GetFrontPage(string id)
        {
            try
            {
                var test = _service.GetFrontPage(id);
                return Ok(test);
            }
            catch
            {
                return BadRequest("error");
            }

        }


        

     
    }
       
}