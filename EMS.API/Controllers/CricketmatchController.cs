using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cricketmatch")]
    public class CricketmatchController : Controller
    {
        private readonly EMSContext _context;
        private readonly CricketmatchServices _service;
        public CricketmatchController(EMSContext context)
        {
            _context = context;
            _service = new CricketmatchServices(_context);
        }


        [HttpPost("addteam")]
        public IActionResult AddCricketTeam([FromForm]GetCricketTeam team)
        {
            CricketTeamRegister TeamReg = new CricketTeamRegister();
            TeamReg.TeamName = team.TeamName;
            TeamReg.EmployeeId = team.TeamCaptainId;
            TeamReg.EventId = team.EventId;
            TeamReg.Description = team.Description;
            TeamReg.LiquorCount = team.LiquorCount;
            TeamReg.VegeCount = team.VageCount;

            int teamId = _service.AddTeam(TeamReg);
            int addcount = 0;
            if (teamId > 0)
            {
                foreach (var m in team.TeamMembers)
                {
                    TeamMember teamMember = new TeamMember();
                    teamMember.CricketTeamRegisterId = teamId;
                    teamMember.EventId = team.EventId;
                    teamMember.IsActive = true;
                    teamMember.EmployeeId = m;
                    Boolean addmember = _service.AddMember(teamMember);
                    if (addmember) { addcount++; }
                }

            }
            if (teamId == -2)
            {
                return BadRequest("Your team name already added!");
            }

            if (teamId > 0 && addcount > 0)
            {
                return Ok("Add a new team success, add " + addcount + " members.");
            }
            return BadRequest("register team error!");

        }
        [HttpGet("viewteammembers/{id}")]
        public IActionResult GetViewEmployeebyEventId(int id) 
        {
            try
            {
                var result =_service.GetViewEmployeebyEventId(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("something error!");
            }
        }

        [HttpGet("deleteteam/{id}")]
        public IActionResult Deleteteam(int id)
        {
            var result = _service.Deleteteam(id);
            if (result)
            {
                return Ok();

            }
            else
            { return BadRequest(); }
        }
        [HttpPost("sendemails")]
        public IActionResult SendEmailCaptain(CaptainEmails ce)
        {
           
         
            Boolean addemail = _service.AddSendemail(ce);
            if (addemail)
            {
                List<string> emails = _service.GetCaptainEmailByeventId(ce.EventId);
                string name = _context.Employees.Where(c => c.Id == ce.SenderId).Select(c => c.EmpName).FirstOrDefault();
                string eventname = _context.Events.Where(c => c.Id == ce.EventId).Select(c=>c.EventTitle).FirstOrDefault();
                foreach (var email in emails)
                {
                    Boolean SendCode = SendMail.SendEmailstoEmployees(ce.Topic, email, name,eventname, ce.Description1, ce.Description2, ce.Description3);
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok();

        }

        

        [HttpGet("getemail/{id}")]
        public IActionResult ViewSendemail(int id)
        {
            var result = _service.ViewSendemail(id);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpGet("getteamsheduler/{id}")]
        public IActionResult ViewTeamSchedules(int id)
        {
            var x = _service.ViewTeamSchedules(id);
            return Ok(x);
        }
        [HttpGet("getcaptainsheduler/{id}")]
        public IActionResult ViewCaptainSchedule(int id)
        {
            var x = _service.ViewCaptainSchedule(id);
            return Ok(x);
        }

        

        [HttpPost("addshedule")]
        public Boolean AddShedule([FromForm]TeamSchedule schedule)
        {
            try {
                return _service.AddShedule(schedule);
            }
            catch
            {
                return false;
            }
            
        }


        /*  public IActionResult ViewSchedule(int id)
          {

              ViewTeamSchedule view = new ViewTeamSchedule();
              view.teamcaptains = _service.ViewCaptainSchedule(id);
              view.teamnames = _service.ViewTeamSchedules(id);
              view.SchName = _context.TeamSchedules.Where(x => x.Id == id && x.IsActive == true).Select(x => x.SchName).FirstOrDefault();

              return Ok(view);
          }*/

        [HttpGet("getshedulebyid/{id}")]
        public ViewTeamSchedule ViewSchedule(int id)
        {
            return _service.ViewSchedule(id);
        }
        [HttpGet("getallshedulebyeventid/{id}")]
        public IActionResult Getallschedule(int id)
        {
            
            try
            {
                var result = _service.Getallschedule(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}