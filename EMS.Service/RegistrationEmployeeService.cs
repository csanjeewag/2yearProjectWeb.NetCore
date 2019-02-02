using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class RegistrationEmployeeService
    {
        private readonly EMS.Data.RegistrationEmployeeRepository _service;

        private readonly EMSContext _context;
        public RegistrationEmployeeService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.RegistrationEmployeeRepository(_context);
        }
        public RegistrationAttribute GetRegistrationAttribute(int id)
        {
            return _service.GetRegistrationAttribute(id);
        }


        public Boolean AddRegistrationAttribute(RegistrationAttribute even)
        {
            return _service.AddRegistrationAttribute(even);
        }

        public Boolean AddEmployee(RegEmployee even)
        {
            return _service.AddEmployee(even);
        }


        public Boolean UpdateRegistrationAttribute(RegistrationAttribute project)
        {
            return _service.UpdateRegistrationAttribute(project);
        }

        public Boolean DeleteEmployee(RegEmployee project)
        {
            return _service.DeleteEmployee(project);
        }


        public IEnumerable<RegEmployee> GetEmployee(string id)
        {

            return _service.GetEmployee(id);

        }

        public RegEmployee GetEmp(string id, string id2)
        {
            return _service.GetEmp(id, id2);
        }
    }
}
