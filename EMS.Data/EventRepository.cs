﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
   public class EventRepository
    {
        private readonly EMSContext _context;
        public EventRepository(EMSContext context)
        {
            _context = context;
        }
        public Boolean AddEvent(Event eve)
        {
            try
            {
              

                _context.Events.Add(eve);
                _context.SaveChanges();
                this.AddNotificationTask(eve);

                return true;
            }
            catch
            {
                return false;
            }
        }
        //create a new event

        public Boolean SelectAttributes(EventAttribute eve)
        {
            try
            {
                _context.EventAttributes.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean UpdateEvent(Event project)
        {
            try
                {
                if (project.EventImageUrl=="")
                {
                    var imageurl = _context.Events.Where(c => c.Id == project.Id).Select(x => x.EventImageUrl).FirstOrDefault();
                    project.EventImageUrl = imageurl;
                }
              
                    _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    this.UpdateNotification(project); //for update notification
                return true;
                }
                catch
                {
                    return false;
                }
            
        }
        public Boolean UpdateAttribute(EventAttribute project)
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
        public Event GetEventDetails(int id)
        {
            
            //int x = Int32.Parse(id);
            var eve = _context.Events
                .Where(c => c.Id == id).FirstOrDefault();

            return eve;

        }
        
        //get details of a selected event
        public EventAttribute GetAttributes(int x)
        {

            //int x = Int32.Parse(id);
            var att = _context.EventAttributes
                .Where(c => c.EventId == x).FirstOrDefault();

            return att;


        }

        public Boolean RegisterForOneDaytrip(OneDayTripRegistrant reg)
        {
            try
            {
                _context.OneDayTripRegistrants.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //add registrant for one day trip


        public Boolean RegisterForTwoDaytrip(TwoDayTripRegistrants reg)
        {
            try
            {
                _context.TwoDayTripRegistrant.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Event> ViewUpComingEvents()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today);

            var even = _context.Events
                .Where(c => c.StartDate >= today)
               .ToList();
            return even;
        }
        public Boolean AddFrontPage(FrontPage page)
        {
            try
            {
                _context.FrontPages.Add(page);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public FrontPage GetFrontPage(string id)
        {
            var test = _context.FrontPages.Where(c => c.CriEventId == id).FirstOrDefault();
            return test;
        }

        public Boolean AddNotificationTask(Event even)
        {
            try
            {
                
                Notification notification = new Notification();
                notification.Data = even.EventTitle + " on " + even.StartDate.ToLongDateString();
                notification.EventId = even.Id;
                notification.DataType = "new event:";
                notification.Date = DateTime.Today;
                notification.Url = "events/vieweventpage/"+even.Id;
                notification.View = false;
                notification.All = true;
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

        public Boolean UpdateNotification(Event even)
        {
            try
            {
              
                var notifications = _context.Notifications.Where(c => c.EventId == even.Id).ToList();
                foreach (var item in notifications)
                {
                    item.Data = even.EventTitle + " on " + even.StartDate.ToLongDateString();
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
    }
}
