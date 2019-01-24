using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
   public class PastEventService
    {
        private readonly EMS.Data.PastEventRepository _service;

        private readonly EMSContext _context;
        public PastEventService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.PastEventRepository(_context);
        }

        public Boolean AddImage(EventImages image, List<string> imageNames)
        {
            return _service.AddImage(image, imageNames);
        }

        public List<EventImages> GetImages(int eventId)
        {
            return _service.GetImages(eventId);
        }

        public List<Event> GetAllEvent()
        {
            return _service.GetAllEvent();
        }

        public Event GetEvent(int id)
        {
            return _service.GetEvent(id);
        }

        public Boolean AddComment(Comment cmt)
        {
            return _service.AddComment(cmt);
        }

        public IEnumerable<Comment> GetComments()
        {

            return _service.GetComments();

        }
    }


}
