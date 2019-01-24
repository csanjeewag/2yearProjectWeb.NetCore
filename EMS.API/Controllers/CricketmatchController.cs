using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}