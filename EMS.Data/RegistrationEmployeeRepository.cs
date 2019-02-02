using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
    public class RegistrationEmployeeRepository
    {
        private readonly EMSContext _context;
        public RegistrationEmployeeRepository(EMSContext context)
        {
            _context = context;
        }

        public RegistrationAttribute GetRegistrationAttribute(int id)
        {


            var eve = _context.RegistrationAttributes
                .Where(c => c.EventId == id).FirstOrDefault();

            return eve;

        }


        public Boolean AddRegistrationAttribute(RegistrationAttribute eve)
        {
            try
            {
                _context.RegistrationAttributes.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean AddEmployee(RegEmployee eve)
        {
            try
            {
                var count = _context.RegEmployees.Where(c => c.IsActive == true && c.EventId == eve.EventId && c.EmployeeId == eve.EmployeeId).Count();
                if (count == 0)
                {
                    _context.RegEmployees.Add(eve);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch
            {
                return false;
            }
        }




        public Boolean UpdateRegistrationAttribute(RegistrationAttribute project)
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

        public Boolean DeleteEmployee(RegEmployee project)
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

        public IEnumerable<RegEmployee> GetEmployee(string id)
        {
            int x = Int32.Parse(id);
            var employees = _context.RegEmployees
                .Where(c => c.IsActive == true && c.EventId == x)
                .ToList();
            return employees;

        }


        public RegEmployee GetEmp(string id, string id2)
        {

            int x = Int32.Parse(id);
            int y = Int32.Parse(id2);
            var eve = _context.RegEmployees
                .Where(c => c.IsActive == true && c.EventId == x && c.EmployeeId == y).FirstOrDefault();

            return eve;

        }
    }

}
