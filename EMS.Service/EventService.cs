using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
    public class EventService
    {
        private readonly EMS.Data.EventRepository _service;

        private readonly EMSContext _context;
        public EventService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.EventRepository(_context);
        }

        public Boolean AddEvent(Event even)
        {
            return _service.AddEvent(even);
        }
        //add an event

        public Boolean UpdateEvent(Event project)
        {
            return _service.UpdateEvent(project);
        }
        
            public Boolean UpdateAttribute(EventAttribute project)
        {
            return _service.UpdateAttribute(project);
        }
        public Boolean SelectAttributes(EventAttribute even)
        {
            return _service.SelectAttributes(even);
        }

        public Event GetEventDetails(string id)
        {
            return _service.GetEventDetails(id);
        }
        //method for get details of a selected event
        
             public EventAttribute GetAttributes(int id)
        {
            return _service.GetAttributes(id);
        }

        public Boolean RegisterForOneDayTrip(OneDayTripRegistrant reg)
        {
            return _service.RegisterForOneDaytrip(reg);
        }
        //add a registrant for single day trip


        public Boolean RegisterForTwoDayTrip(TwoDayTripRegistrants reg)
        {
            return _service.RegisterForTwoDaytrip(reg);
        }
        //add a registrant for multiple day trip


        public IEnumerable<Event> ViewUpComingEvents()
        {
            return _service.ViewUpComingEvents();
        }
        //get details of up coming events filter by startdate

        public Boolean AddFrontPage(FrontPage page)
        {
            return _service.AddFrontPage(page);
        }

        public FrontPage GetFrontPage(string id)
        {
            return _service.GetFrontPage(id);
        }

       

        

       

       
    }
}
