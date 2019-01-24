using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Service
{
 public class CricketmatchServices
    {
        private readonly EMS.Data.CricketmatchRepository _service;


        private readonly EMSContext _context;
        public CricketmatchServices(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.CricketmatchRepository(_context);
        }

        public int AddTeam(CricketTeamRegister team)
        {
            return _service.AddTeam(team);
        }
        public Boolean AddMember(TeamMember teamMember)
        {
            return _service.AddMember(teamMember);
        }

        public List<ViewTeamMember> GetViewEmployeebyEventId(int eventid)
        {
            return _service.GetViewEmployeebyEventId(eventid);
        }
    }
}
