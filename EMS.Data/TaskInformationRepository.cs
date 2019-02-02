using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;


namespace EMS.Data
{
   public  class TaskInformationRepository
    {
        private readonly EMSContext _context;
        public TaskInformationRepository(EMSContext context)
        {
            _context = context;
        }

        /// <summary>
        /// add task information by employee
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        public Boolean AddTaskInformation(TaskInformation tinfo)
        {
            try
            {
                tinfo.IsActive = true;
                _context.TaskInformations.Add(tinfo);
                _context.SaveChanges();
                return true;
                
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public IEnumerable<TaskInformation> GetInformation()
        {
            var test = _context.TaskInformations
                .Where(e => e.IsActive == true)
              .ToList();
            return test;

        }


        public IEnumerable<TaskInformation> GetInfoById(int id)
        {
            var test = _context.TaskInformations
                .Where(et => et.TaskTaskId == id && et.IsActive== true)
                .ToList();
            return test;

        }

        /// <summary>
        /// add contact detal comming from task information 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public int AddContactDetail(ContactDetails c)
        {
            try
            {
                c.IsActive = true;
                _context.ContactDetails.Add(c);
                _context.SaveChanges();
                int result = _context.ContactDetails.Max(p => p.ContactDetailId);
                return result;
            }
            catch
            {
                return 0;
            }
        }



        public Boolean UpdateTaskInformation(TaskInformation t)
        {
            try
            {
                t.IsActive = true;
                _context.Entry(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean DeleteInformation(int id)
        {

            try
            {
                var info = _context.TaskInformations.Where(c => c.IsActive == true && c.InfoID == id)
                .FirstOrDefault();
                info.IsActive = false;
                _context.Entry(info).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        

             public IEnumerable<TaskInformation> GetTaskInformationkBytaskId(int id)
        {



            var test = _context.TaskInformations
                .Where(et => et.TaskTaskId == id && et.IsActive == true)
                //.Select(et => et.Task)
                .ToList();
            return test;

        }

    }
}
