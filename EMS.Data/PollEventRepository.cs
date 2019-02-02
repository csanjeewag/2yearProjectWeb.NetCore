using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class PollEventRepository
    {
        private readonly EMSContext _context;
        public PollEventRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean CreatePoll(Poll eve)
        {
            try
            {
                _context.Polls.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Add a new Poll

        public Boolean AddDestination(Destination eve)
        {
            try
            {
                _context.Destinations.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Add destinations for new poll

        public Poll GetPoll(string id)
        {

            int x = Int32.Parse(id);
            var eve = _context.Polls
                .Where(c => c.Id == x).FirstOrDefault();

            return eve;

        }
        //get details of selected vote

        public IEnumerable<Destination> GetDestination(string id)
        {
            int x = Int32.Parse(id);
            var dest = _context.Destinations
                .Where(c => c.PollId == x)
                .ToList();
            return dest;

        }
        //get details of destinations of selected poll

        public VotedEmployees GetEmp(int id, int id2)
        {


            var eve = _context.VotedEmployee
                .Where(c => c.PollId == id && c.EmployeeId == id2).FirstOrDefault();

            return eve;

        }
        //check whether the selected employee has voted

        public Boolean AddVote(Destination project)
        {
            try
            {

                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        //add vote to a destination

        public Boolean AddEmployee(VotedEmployees project)
        {
            try
            {

                _context.VotedEmployee.Add(project);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean RemovePoll(Poll project)
        {
            try
            {

                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
