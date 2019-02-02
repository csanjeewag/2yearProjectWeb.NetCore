﻿using System;
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
using Task = EMS.Data.Models.Task;

namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/task")]
    public class TaskController:Controller
    {
        private readonly EMSContext _context;
        private readonly TaskService _service;
       
        public TaskController(EMSContext context)
        {
            _context = context;
            _service = new TaskService(_context);
        }


        /// <summary>
        /// By the url of 'task/getallforemployee' return all tasks for the particular emp
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All assigned task for empId=id </returns>

        [Produces("application/json")]
        [HttpGet("gettaskforemp/{id}")]
        public IEnumerable<Task> GetTaskForEmployee(int id)
        {
            return _service.GetTaskForEmployee(id);

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// 

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult AddTask([FromBody]GetTask t)
        {
            Task task = new Task();
            task.TaskId = t.TaskId;
            task.EventId = t.EventId;
            task.EndDate = t.EndDate;
            task.StartDate = t.StartDate;
            task.Status = t.Status;
            task.TaskName = t.TaskName;
            task.Description = t.Description;
            task.BudgetedCost = t.BudgetedCost;
            task.AddDate = t.AddDate;


            int taskid = _service.AddTask(task);

            if (taskid != 0)
              
            {

                EmployeeTask eTask = new EmployeeTask();
                //eTask.EmpId = t.Employees[0];
                int x = 0;
                foreach (var i in t.Employees)
                {
                   // int x = Int32.Parse(i);
                    eTask.EId = t.Employees[x];
                    eTask.TaskId = taskid;

                    _service.AddEmployeeTask(eTask);
                    _service.AddNotificationTask(eTask, task);
                    x++;
                }
               

                return Ok(t);
            }
            else
            {
                return BadRequest("error");
            }
        }
        [Produces("application/json")]
        [HttpGet("getcompletedtasks")]
        public IActionResult GetContactTypes()
        {


            var result = _service.GetComletedTasks();
            return Ok(result);


        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetTaskDetails()
        {


            var result = _service.GetTaskDetails();
            return Ok(result);


        }
        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public IActionResult GetTaskDetailsbyevent(int id)
        {


            var result = _service.GetTaskDetails().Where(x=>x.EventId == id).ToList();
            return Ok(result);


        }

        /*[Produces("application/json")]
        [HttpGet("getall/{id}")]
        public IActionResult GetTaskDetails(string id)
        {


            var result = _service.GetTaskDetails(id);
            return Ok(result);


        }
        */
        /// <summary>
        /// Get Tasks by their TaskID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A task with the url 'task/{id}'</returns>

        [Produces("application/json")]
        [HttpGet("{id}")]

        public Task GetTaskById(int id)
        {
            return _service.GetTaskById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        
      /*  [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatetask")]
        public IActionResult UpdateTask([FromForm]GetTask t)
        {

            Task task = new Task();
            task.EventName = t.EventName;
            task.EndDate = t.EndDate;
            task.StartDate = t.StartDate;
            task.Status = t.Status;
            task.TaskName = t.TaskName;
            task.Description = t.Description;
            task.BudgetedCost = t.BudgetedCost;
            task.AddDate = t.AddDate;

            EmployeeTask eTask = new EmployeeTask();
            //eTask.EmpId = t.Employees[0];
            int x = 0;
            foreach (var i in t.Employees)
            {
                // int x = Int32.Parse(i);
                eTask.EId = t.Employees[x];                
                _service.AddEmployeeTask(eTask);
                x++;
            }
        }*/


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>

         /*[Produces("application/json")]
         [Consumes("application/json")]
         [HttpPost("addinfo")]
         public IActionResult AddInformation([FromBody]TaskInformation tinfo)
         {

             if (_service.AddInformation(tinfo))
             {

                 return Ok(tinfo);
             }
             else
             {
                 return BadRequest("error");
             }
         }*/

        [Produces("application/json")]
        [HttpGet("getempfortask/{id}")]
        public IEnumerable<Employee> GetEmployeesForTask(int id)
        {
            return _service.GetEmployeesForTask(id);

        }

        [HttpGet("deletetask/{id}")]
        public Boolean DeleteTask(int id)
        {
            return _service.DeleteTask(id);
        }




    }

}
