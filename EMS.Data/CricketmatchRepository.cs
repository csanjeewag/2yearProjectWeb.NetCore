using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Data
{
  public class CricketmatchRepository
    {
        private readonly EMSContext _context;
        public CricketmatchRepository(EMSContext context)
        {
            _context = context;
        }

        public int AddTeam(CricketTeamRegister team)
        {
            try
            {
                int checkname = _context.cricketTeamRegisters.Where(c => c.TeamName == team.TeamName && c.EventId == team.EventId).Select(c => c.Id).FirstOrDefault();
                if(checkname > 0)
                {
                    return -2;
                }
                DateTime today = DateTime.Today;
                team.Registerdate = today;
                team.IsActive = true;

                _context.cricketTeamRegisters.Add(team);
                _context.SaveChanges();

                int teamid = _context.cricketTeamRegisters.Max(c => c.Id);
                return teamid;
            }
            catch
            {
                return -1;
            }
        }

        public Boolean AddMember(TeamMember teamMember)
        {
            try
            {
                
                 _context.TeamMembers.Add(teamMember);
                 _context.SaveChanges();
              
                return true;
            }
            catch
            {
                return false; ;
            }
           
        }
        public List<string> getNameById(List<int> id)
        {
            var names = new List<string>();
            foreach(var i in id)
            {
                string name = _context.Employees.Where(c => c.Id == i).Select(c => c.EmpName).FirstOrDefault();
                names.Add(name);
            }
            
            return names;

        }
        public List<string> GetmebersByTeamId(int teamid)
        {
            var teamIds = new List<int>();
            teamIds = _context.TeamMembers.Where(c => c.CricketTeamRegisterId == teamid).Select(c => c.EmployeeId).ToList();
           return this.getNameById(teamIds);
            

        }
        public ViewTeamMember GetViewDetailsByTeamId(int teamid)
        {
            var teamdetails = _context.cricketTeamRegisters.Where(c => c.Id == teamid && c.IsActive == true).FirstOrDefault();
            var teamnames = new List<string>();
            teamnames = GetmebersByTeamId(teamid);
            ViewTeamMember view = new ViewTeamMember();
            view.Id = teamid;
            view.TeamName = teamdetails.TeamName;
            view.VegeCount = teamdetails.VegeCount;
            view.LiquorCount = teamdetails.LiquorCount;
            view.Capatain = _context.Employees.Where(c => c.Id == teamdetails.EmployeeId ).Select(c => c.EmpName).FirstOrDefault();
            view.Registerdate = teamdetails.Registerdate;
            view.Description = teamdetails.Description;
            view.EmployeeNames = teamnames;
            return view;
        }

        public List<ViewTeamMember> GetViewEmployeebyEventId(int eventid)
        {
            var viewemployees = new List<ViewTeamMember>() ;
            var teamIds = new List<int>();
            teamIds = _context.cricketTeamRegisters.Where(c => c.EventId == eventid && c.IsActive == true).Select(c=> c.Id).ToList();

            foreach (var id in teamIds)
            {
                var view = GetViewDetailsByTeamId(id);
                viewemployees.Add(view);
            }
            return viewemployees;
        }

        
    }
}
