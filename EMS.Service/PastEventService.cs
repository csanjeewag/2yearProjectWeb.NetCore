using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;
using EMS.Data.ViewModels;

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
        public Boolean EditComment(Comment cmt)
        {

            return _service.EditComment(cmt);
        }

        public IEnumerable<ViewEmployeeforcomment> GetComments(int id)
        {

            return _service.GetComments(id);

        }

        public Boolean Delete(string img)
        {
            
            return _service.Delete(img);
        }

        public Boolean Deletecomment( int id)
        {

            return _service.Deletecomment(id);
        }
    }


}
