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
        public List<string> getEmailById(List<int> id)
        {
            var names = new List<string>();
            foreach (var i in id)
            {
                string name = _context.Employees.Where(c => c.Id == i).Select(c => c.EmpEmail).FirstOrDefault();
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

        public Boolean Deleteteam(int id)
        {

             try
             {
                 var deleteteam = _context.cricketTeamRegisters.Where(c => c.Id == id)
                 .FirstOrDefault();
                 deleteteam.IsActive = false;
                 _context.Entry(deleteteam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                 _context.SaveChanges();
                 return true;
             }
             catch { return false; }
            
        }
        public List<string> GetCaptainEmailByeventId(int id)
        {
            
                List<int> captainId = _context.cricketTeamRegisters.Where(c => c.IsActive == true && c.EventId == id).Select(c => c.EmployeeId).ToList();
                List<string> captainmail = getEmailById(captainId);
                return captainmail;
            
            
        }
        public Boolean AddSendemail(CaptainEmails input)
        {
            try
            {   input.senderdate = DateTime.Today;
                
                var result = _context.CaptainEmails.Add(input);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CaptainEmails ViewSendemail( int eventId)
        {
            try
            {
            
               var result = _context.CaptainEmails.Where(c => c.EventId == eventId).FirstOrDefault();
               var sendername = _context.Employees.Where(c => c.Id == result.SenderId).Select(c => c.EmpName).FirstOrDefault();
                var eventname = _context.Events.Where(c => c.Id == result.EventId).Select(c => c.EventTitle).FirstOrDefault();
                result.Eventname = eventname;
                result.Sendername = sendername;
                return result;
            }
            catch
            {
                return null;
            }
        }
        public Boolean AddShedule(TeamSchedule schedule)
        {
            try
            {
                schedule.IsActive = true;
                schedule.SchDate = DateTime.Today;
                var result = _context.TeamSchedules.Add(schedule);
                
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public string GetEmployeename(int id)
        {
            return _context.Employees.Where(c => c.Id == id).Select(c => c.EmpName).FirstOrDefault();
        }

        public string GetTeamName(int id)
        {
            try
            {
                return _context.cricketTeamRegisters.Where(c => c.Id == id).Select(c => c.TeamName).FirstOrDefault();

            }
            catch
            {
                return "";
            }

        }


        public List<string> ViewTeamSchedule(int eventId)
        {
            try
            {
                TeamSchedule teamshedule = _context.TeamSchedules.Where(c => c.EventId == eventId && c.IsActive== true).OrderByDescending(c => c.Id).FirstOrDefault();

                var list = new List<string>();

                // var  list = new List<string>[20];
                
                list.Add(GetTeamName(teamshedule.team1));               
                list.Add(GetTeamName(teamshedule.team2));        
                list.Add(GetTeamName(teamshedule.team3));
                list.Add(GetTeamName(teamshedule.team4));
                list.Add(GetTeamName(teamshedule.team5));
                list.Add(GetTeamName(teamshedule.team6));
                list.Add(GetTeamName(teamshedule.team7));
                list.Add(GetTeamName(teamshedule.team8));
                list.Add(GetTeamName(teamshedule.team9));
                list.Add(GetTeamName(teamshedule.team10));
                list.Add(GetTeamName(teamshedule.team11));
                list.Add(GetTeamName(teamshedule.team12));
                list.Add(GetTeamName(teamshedule.team13));
                list.Add(GetTeamName(teamshedule.team14));
                list.Add(GetTeamName(teamshedule.team15));
                list.Add(GetTeamName(teamshedule.team16));
                return list;
            }
            catch
            {
                return null;
            }
          

        }

        public string GetCaptainbyid(int id)
        {
            try
            {
                var EId= _context.cricketTeamRegisters.Where(c => c.Id == id).Select(c => c.EmployeeId).FirstOrDefault();
                return _context.Employees.Where(c => c.Id == EId).Select(c => c.EmpName).FirstOrDefault();

            }
            catch
            {
                return "";
            }
        }

        public List<string> ViewCaptainSchedule(int eventId)
        {
            try
            {
                TeamSchedule teamshedule = _context.TeamSchedules.Where(c => c.EventId == eventId &&c.IsActive==true).OrderByDescending(c => c.Id).FirstOrDefault();

                var list = new List<string>();

                // var  list = new List<string>[20];

                list.Add(GetCaptainbyid(teamshedule.team1));
                list.Add(GetCaptainbyid(teamshedule.team2));
                list.Add(GetCaptainbyid(teamshedule.team3));
                list.Add(GetCaptainbyid(teamshedule.team4));
                list.Add(GetCaptainbyid(teamshedule.team5));
                list.Add(GetCaptainbyid(teamshedule.team6));
                list.Add(GetCaptainbyid(teamshedule.team7));
                list.Add(GetCaptainbyid(teamshedule.team8));
                list.Add(GetCaptainbyid(teamshedule.team9));
                list.Add(GetCaptainbyid(teamshedule.team10));
                list.Add(GetCaptainbyid(teamshedule.team11));
                list.Add(GetCaptainbyid(teamshedule.team12));
                list.Add(GetCaptainbyid(teamshedule.team13));
                list.Add(GetCaptainbyid(teamshedule.team14));
                list.Add(GetCaptainbyid(teamshedule.team15));
                list.Add(GetCaptainbyid(teamshedule.team16));
                return list;
            }
            catch
            {
                return null;
            }


        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////



        public List<string> ViewTeamSchedulebyID(int Id)
        {
            try
            {
                TeamSchedule teamshedule = _context.TeamSchedules.Where(c => c.Id == Id && c.IsActive == true).OrderByDescending(c => c.Id).FirstOrDefault();

                var list = new List<string>();

                // var  list = new List<string>[20];

                list.Add(GetTeamName(teamshedule.team1));
                list.Add(GetTeamName(teamshedule.team2));
                list.Add(GetTeamName(teamshedule.team3));
                list.Add(GetTeamName(teamshedule.team4));
                list.Add(GetTeamName(teamshedule.team5));
                list.Add(GetTeamName(teamshedule.team6));
                list.Add(GetTeamName(teamshedule.team7));
                list.Add(GetTeamName(teamshedule.team8));
                list.Add(GetTeamName(teamshedule.team9));
                list.Add(GetTeamName(teamshedule.team10));
                list.Add(GetTeamName(teamshedule.team11));
                list.Add(GetTeamName(teamshedule.team12));
                list.Add(GetTeamName(teamshedule.team13));
                list.Add(GetTeamName(teamshedule.team14));
                list.Add(GetTeamName(teamshedule.team15));
                list.Add(GetTeamName(teamshedule.team16));
                return list;
            }
            catch
            {
                return null;
            }


        }
        public List<string> ViewCaptainSchedulebyId(int Id)
        {
            try
            {
                TeamSchedule teamshedule = _context.TeamSchedules.Where(c => c.Id == Id && c.IsActive == true).OrderByDescending(c => c.Id).FirstOrDefault();

                var list = new List<string>();

                // var  list = new List<string>[20];

                list.Add(GetCaptainbyid(teamshedule.team1));
                list.Add(GetCaptainbyid(teamshedule.team2));
                list.Add(GetCaptainbyid(teamshedule.team3));
                list.Add(GetCaptainbyid(teamshedule.team4));
                list.Add(GetCaptainbyid(teamshedule.team5));
                list.Add(GetCaptainbyid(teamshedule.team6));
                list.Add(GetCaptainbyid(teamshedule.team7));
                list.Add(GetCaptainbyid(teamshedule.team8));
                list.Add(GetCaptainbyid(teamshedule.team9));
                list.Add(GetCaptainbyid(teamshedule.team10));
                list.Add(GetCaptainbyid(teamshedule.team11));
                list.Add(GetCaptainbyid(teamshedule.team12));
                list.Add(GetCaptainbyid(teamshedule.team13));
                list.Add(GetCaptainbyid(teamshedule.team14));
                list.Add(GetCaptainbyid(teamshedule.team15));
                list.Add(GetCaptainbyid(teamshedule.team16));
                return list;
            }
            catch
            {
                return null;
            }


        }

        public ViewTeamSchedule ViewSchedule(int id)
        {

            ViewTeamSchedule view = new ViewTeamSchedule();
            view.teamcaptains = ViewCaptainSchedulebyId(id);
            view.teamnames = ViewTeamSchedulebyID(id);
            view.IsActive = true;
            view.SchName = _context.TeamSchedules.Where(x => x.Id == id && x.IsActive == true).Select(x => x.SchName).FirstOrDefault();

            return view;
        }

        public List<TeamSchedule> Getallschedule(int eventId)
        {
            try
            {
                return _context.TeamSchedules.Where(c => c.EventId == eventId && c.IsActive == true).ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
