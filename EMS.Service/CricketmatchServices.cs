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

        public Boolean Deleteteam(int id)
        {

            return _service.Deleteteam(id);
        }

        public List<string> GetCaptainEmailByeventId(int id)
        {
            return _service.GetCaptainEmailByeventId(id);
        }

        public Boolean AddSendemail(CaptainEmails input)
        {
            return _service.AddSendemail(input);
        }
        public CaptainEmails ViewSendemail(int eventid)
        {
            return _service.ViewSendemail(eventid);
        }

        public List<string> ViewTeamSchedules(int eventId)
        {
            return _service.ViewTeamSchedule(eventId);
        }
        public List<string> ViewCaptainSchedule(int eventId)
        {
            return _service.ViewCaptainSchedule(eventId);
        }
        public Boolean AddShedule(TeamSchedule eventId)
        {
            return _service.AddShedule(eventId);
        }

        public ViewTeamSchedule ViewSchedule(int id)
        {
            return _service.ViewSchedule(id);
        }

        public List<TeamSchedule> Getallschedule(int eventId)
        {
            return _service.Getallschedule(eventId);
        }


    }
}
