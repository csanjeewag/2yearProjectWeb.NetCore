using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class NotificationRepoitory
    {

        private readonly EMSContext _context;
        public NotificationRepoitory(EMSContext context)
        {
            _context = context;
        }

        public List<Notification> ViewNotifation(int EmpId)
        {
            try {
                var list1 = _context.Notifications.Where(c => c.EmployeeId == EmpId && c.View == false).ToList();
                var list2 = _context.Notifications.Where(c =>c.All == true).ToList();
                var list3 = this.RemoveFromList(list2,EmpId);
                var list =  list1.Concat(list3).ToList();
                return list;
            }
            
            catch
            {
                return null;
            }
        }
        public List<Notification> RemoveFromList(List<Notification> input, int EmpId)
        {
            List<Notification> list = new List<Notification>();
            foreach (var item in input)
            {

                var checkresult = _context.NotificationViewEmployees.Where(c => c.NotificationId == item.Id && c.EmployeeId== EmpId).Select(c => c.Id).FirstOrDefault();

                if (checkresult <= 0)
                {
                    list.Add(item);
                }
                
            }
            return list;
        }
        public Boolean RemoveNotification(int id, int empId)
        {
            try
            {

                var result = _context.Notifications.Where(c => c.Id == id).FirstOrDefault();
                    if(result.All == true)
                {
                    NotificationViewEmployee notificationViewEmployee = new NotificationViewEmployee();
                    notificationViewEmployee.EmployeeId = empId;
                    notificationViewEmployee.NotificationId = id;
                    notificationViewEmployee.View = true;
                    _context.NotificationViewEmployees.Add(notificationViewEmployee);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    result.View = true;
                    _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                   
            
            }
            catch
            {
                return false;
            }
        }

        

        public Boolean SpecialaNotification(Notification input)
        {
            try
            {
                Notification notification = new Notification();
                notification.Data = input.Data;
                notification.DataType = input.DataType;
                notification.Date = DateTime.Today;
                notification.EmployeeId = input.EmployeeId;
                notification.Url = notification.Url;
                notification.View = false;
                notification.All = false;
                notification.senderId = input.senderId;
                notification.Sendernme = _context.Employees.Where(c => c.Id == input.senderId).Select(c => c.EmpName).FirstOrDefault();
                _context.Notifications.Add(notification);
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
