using EMS.Data.Models;
using EMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Service
{
    public class ContactService
    {
        private readonly EMS.Data.ContactRepository _service;


        private readonly EMSContext _context;
        public ContactService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.ContactRepository(_context);
        }

        public IEnumerable<Contact> GetContactTypes()
        {

            return _service.GetContactTypes();

        }

        public Boolean AddContactType(Contact c)
        {
            return _service.AddContactType(c);
        }

        public int AddContactDetail(ContactDetails c)
        {
            return _service.AddContactDetail(c);
        }

        
            public Boolean AddContactDetailNormally(ContactDetails c)
        {
            return _service.AddContactDetailNormally(c);
        }

        public IEnumerable<ContactDetails> GetAllForType(int id)
        {

            return _service.GetAllForType(id);

        }
        public Boolean UpdateContactType(Contact c) {
            return _service.UpdateContactType(c);
        }

        public Boolean DeleteContactType(int id)
        {
            return _service.DeleteContactType(id);
        }
        public Boolean DeleteContactDetail(int id)
        {
            return _service.DeleteContactDetail(id);
        }

        public Boolean UpdateContactDetail(ContactDetails c)
        {
            return _service.UpdateContactDetail(c);
        }
        public IEnumerable<ContactDetails> GetContactDetailsByTaskId(int id) {
           return  _service.GetContactDetailsByTaskId(id);
        }
    }
}
