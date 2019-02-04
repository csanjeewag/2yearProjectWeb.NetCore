using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class PollEventService
    {
        private readonly EMS.Data.PollEventRepository _service;

        private readonly EMSContext _context;
        public PollEventService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.PollEventRepository(_context);
        }

        public Boolean CreatePoll(Poll even)
        {
            return _service.CreatePoll(even);
        }
        public Boolean AddDestination(Destination even)
        {
            return _service.AddDestination(even);
        }

        public Poll GetPoll(string id)
        {
            return _service.GetPoll(id);
        }

        public Poll GetLastPoll()
        {
            return _service.GetLastPoll();
        }
        public IEnumerable<Destination> GetDestination(string id)
        {

            return _service.GetDestination(id);

        }

        public VotedEmployees GetEmp(int id, int id2)
        {
            return _service.GetEmp(id, id2);
        }

        public Boolean AddVote(Destination project)
        {
            return _service.AddVote(project);
        }

        public Boolean AddEmployee(VotedEmployees project)
        {
            return _service.AddEmployee(project);
        }


        public Boolean RemovePoll(Poll project)
        {
            return _service.RemovePoll(project);
        }


    }
}
