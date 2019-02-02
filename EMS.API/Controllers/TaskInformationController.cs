using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskInformation = EMS.Data.Models.TaskInformation;


namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/taskinfo")]

    public class TaskInformationController:Controller
    {
        private readonly EMSContext _context;
        private readonly TaskInformationService _service;
        

        public TaskInformationController(EMSContext context)
        {
            _context = context;
            _service = new TaskInformationService(_context);

            
        }

        /// <summary>
        /// get information by its task id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("{id}")]

        public IEnumerable<TaskInformation> GetTaskInformationkBytaskId(int id)
        {
            return _service.GetTaskInformationkBytaskId(id);

        }



        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetInformation()
        {


            var result = _service.GetInformation();
            return Ok(result);


        }
       
      
        [HttpPost("addinfodetails")]
        public IActionResult AddTaskInformation([FromForm]GetTaskInformation c)
        {
            ContactDetails cdetails = new ContactDetails();
            cdetails.ContactContactId = c.ContactContactId;
            cdetails.Name = c.Name;
            cdetails.Number1 = c.Contact1;
            cdetails.Number2 = c.Contact2;
            cdetails.Address = c.Address;
            cdetails.ContactDescription = c.ContactDescription;
            cdetails.TaskId = c.TaskTaskId;
            cdetails.EmployeeId = c.EmployeeId;
         //   cdetails.ContactDetailId = c.ContactId;
           // cdetails.ContactContactId = c.ContactContactId;
            cdetails.IsActive = true;

            int contactId = _service.AddContactDetail(cdetails);
            if (contactId != 0)

            {
                TaskInformation taskinfo = new TaskInformation();
                taskinfo.ContactContactId = c.ContactContactId;
                taskinfo.InfoDescription = c.InfoDescription;
                taskinfo.EmployeeId = c.EmployeeId;
                //taskinfo.IsComplete = c.IsComplete;
                taskinfo.TaskTaskId = c.TaskTaskId;
           
                taskinfo.IsActive=true;
                taskinfo.IsComplete = true;

               var result = _service.AddTaskInformation(taskinfo);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
                
            }
           else
            {
                return BadRequest("error");
          }


           
        }


        [HttpPost("updatetaskinfo")]
        public IActionResult UpdateTaskInformation([FromForm]TaskInformation c)
        {

            if (_service.UpdateTaskInformation(c))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [HttpGet("deletetaskinfo/{id}")]
        public Boolean DeleteInformation(int id)
        {
            return _service.DeleteInformation(id);
        }




    }
}
