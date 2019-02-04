using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Data
{
    public class ContactRepository
    {
        private readonly EMSContext _context;
        public ContactRepository(EMSContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetContactTypes()
        {
            
            var test = _context.Contacts
                .Where(c => c.IsActive == true)
              .ToList();
            return test;

        }

        public Boolean AddContactType(Contact c)
        {
            try
            {
                c.IsActive = true;
                _context.Contacts.Add(c);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


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

        public Boolean AddContactDetailNormally(ContactDetails c)
        {
            try
            {
                c.IsActive = true;
                _context.ContactDetails.Add(c);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public IEnumerable<ContactDetails> GetAllForType(int id) {
            var test = _context.ContactDetails
                .Where(e => e.ContactContactId == id && e.IsActive == true)
              // .Select(et => et.TaskInformation)
                .ToList();
            return test;

        }

        public Boolean UpdateContactType(Contact c) {
            try
            {
                _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Boolean DeleteContactType(int id) {
           
                var result = _context.Contacts.Where(c => c.IsActive == true && c.ContactId == id).FirstOrDefault();
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
        public Boolean DeleteContactDetail(int id)
        {

            var result = _context.ContactDetails.Where(c => c.IsActive == true && c.ContactDetailId == id).FirstOrDefault();
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
        public Boolean UpdateContactDetail(ContactDetails c)
        {
            try
            {
                c.IsActive = true;
                _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// get contacts details by task id
        /// </summary>
        public List<ContactDetails>  GetContactDetailsByTaskId(int id) {
            try
            {
                var test = _context.ContactDetails
           .Where(et => et.TaskId == id && et.IsActive == true)
           //.Select(et => et.Task)
           .ToList();
                return test;
            }
            catch
            {
                return null;
            }
        
        }

        public ContactDetails GetContactDetailsById(int id)
        {
            var test = _context.ContactDetails
               .Where(et => et.ContactDetailId == id && et.IsActive == true)
               //.Select(et => et.Task)
               .FirstOrDefault();
            return test;
        }

    }
}
