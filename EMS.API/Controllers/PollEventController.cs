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
    [Route("api/PollEvent")]
    public class PollEventController : Controller
    {
        private readonly EMSContext _context;
        private readonly PollEventService _service;
        public PollEventController(EMSContext context)
        {
            _context = context;
            _service = new PollEventService(_context);
        }


        [HttpPost("createPoll")]
        public IActionResult CreatePoll([FromForm]Poll even)
        {

            if (_service.CreatePoll(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //Add new poll

        [HttpPost("addDestination")]
        public IActionResult AddDestination([FromForm]Destination even)
        {

            if (_service.AddDestination(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //Add destinations to the new poll


        [Produces("application/json")]
        [HttpGet("getPoll/{id}")]
        public Poll GetPoll(string id)
        {
            return _service.GetPoll(id);
        }

        [Produces("application/json")]
        [HttpGet("getDestination/{id}")]
        public IEnumerable<Destination> GetDestination(string id)
        {
            return _service.GetDestination(id);

        }
        //Get destination details of the selected poll

        [Produces("application/json")]
        [HttpGet("getEmp/{id}/{id2}")]
        public VotedEmployees GetEmp(int id, int id2)
        {
            return _service.GetEmp(id, id2);
        }
        //CHeck whether a employee has voted for the poll
        [HttpPost("addEmployee")]
        public IActionResult AddEmployee([FromForm]VotedEmployees project)
        {

            if (_service.AddEmployee(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [HttpPost("addVote")]
        public IActionResult AddVote([FromForm]Destination project)
        {

            if (_service.AddVote(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }
        //Add vote for the poll

        [HttpPost("removePoll")]
        public IActionResult RemovePoll([FromForm]Poll project)
        {

            if (_service.RemovePoll(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }
        //Remove poll from active poll state
    }
}