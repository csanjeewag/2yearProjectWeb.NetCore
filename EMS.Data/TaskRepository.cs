using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;


namespace EMS.Data
{
    public class TaskRepository
    {
        private readonly EMSContext _context;
        public TaskRepository(EMSContext context)
        {
            _context = context;
        }


        /// <summary>
        /// get task by emp id
        /// </summary>
        /// <returns>List of tasks assigned to empid=id employee</returns>        
        public IEnumerable<Task> GetTaskForEmployee(int id)
        {
            
           
            var test = _context.EmployeeTasks
                .Where(et => et.EId == id )
                .Select(et => et.Task)
                .ToList();
            return test;
        }
        


        /// <summary>
        /// Insert a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>State of adding a task</returns>
        public int AddTask(Task task)
        {
            try
            {
                if (task.TaskId == 0)
                {
                    task.IsActive = true;
                    task.AddDate = DateTime.Today;
                    _context.Tasks.Add(task);
                    _context.SaveChanges();

                    int result = _context.Tasks.Max(p => p.TaskId);

                return result;
                }
                else
                {
                    DateTime adddate = _context.Tasks.Where(c => c.TaskId == task.TaskId).Select(c => c.AddDate).FirstOrDefault();
                    task.AddDate = adddate;
                    task.IsActive = true;
                    this.UpdateNotification(task);
                    _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    return _context.Tasks.Max(p => p.TaskId);
                }
            }
            catch
            {
                return 0;
            }
        }



    /// <summary>
    /// Add details for EmployeeTask table
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
        public Boolean AddEmployeeTask(EmployeeTask etask)
        {
            try
            {

                _context.EmployeeTasks.Add(etask);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean AddNotificationTask(EmployeeTask etask, Task task)
        {
            try
            {
                var eventname = _context.Events.Where(c => c.Id == task.EventId).Select(c => c.EventTitle).FirstOrDefault();

                Notification notification = new Notification();
                notification.Data = task.TaskName+" for "+ eventname;
                notification.TaskId = task.TaskId;
                notification.DataType = "new task for you:";
                notification.Date = DateTime.Today;
                notification.EmployeeId = etask.EId;
                notification.Url = notification.Url;
                notification.View = false;
                notification.All = false;
                notification.senderId = 0;
                notification.Sendernme = "Recreation committee";
                _context.Notifications.Add(notification);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean UpdateNotification( Task task)
        {
            try
            {
                var eventname = _context.Events.Where(c => c.Id == task.EventId).Select(c => c.EventTitle).FirstOrDefault();
                var taskname = _context.Tasks.Where(c => c.TaskId == task.TaskId).Select(c => c.TaskName).FirstOrDefault();

                var notifications = _context.Notifications.Where(c => c.TaskId == task.TaskId).ToList();
                foreach (var item in notifications)
                {
                    item.Data = task.TaskName + " for " + eventname;
                    _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Return task by Task ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task with the id TaskId=id</returns>
        public Task GetTaskById(int id)
        {

           

            var test = _context.EmployeeTasks
                .Where(et => et.TaskId == id )
                .Select(et => et.Task)
                .FirstOrDefault();
            return test;
          
        }

       /* /// <summary>
        /// Task Update
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Boolean UpdateTask(Task task)
        {
            try
            {

                _context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        */


        public IEnumerable<Task> GetTaskDetails()
        {
            var test = _context.Tasks.Where(c=>c.IsActive == true)
             
              .ToList();
            return test;

        }
        public IEnumerable<Employee> GetEmployeesForTask(int id) {
            var test = _context.EmployeeTasks
                .Where(et => et.TaskId == id)
                .Select(et => et.Employee)
                .ToList();
            return test;

        }

        public Boolean DeleteTask(int id)
        {
            var result = _context.Tasks.Where(c => c.IsActive == true && c.TaskId == id).FirstOrDefault();
            try
            {
                result.IsActive = false;
                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<Task> GetComletedTasks() {
            var test = _context.Tasks
                .Where(e => e.Status == true && e.IsActive == true)
                // .Select(et => et.TaskInformation)
                .ToList();
            return test;
        }



    }
}
