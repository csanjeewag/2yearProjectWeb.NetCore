using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
   public class NotificationService
    {
        private readonly EMS.Data.NotificationRepoitory _service;


        private readonly EMSContext _context;
        public NotificationService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.NotificationRepoitory(_context);
        }

        public List<Notification> ViewNotifation(int EmpId)
        {
            return _service.ViewNotifation(EmpId);
        }

        public Boolean RemoveNotification(int id, int empId)
        {
            return _service.RemoveNotification(id,empId);
        }

        public Boolean SpecialaNotification(Notification input)
        {
            return _service.SpecialaNotification(input);
        }
    }
}
