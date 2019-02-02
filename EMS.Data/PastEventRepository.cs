using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;
using EMS.Data.ViewModels;

namespace EMS.Data
{
  public  class PastEventRepository
    {
        private readonly EMSContext _context;
        public PastEventRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddImage( EventImages image, List<string> imageNames)
        {
            try
            {

                

                foreach (var imageName in imageNames)
                {

                    DateTime today = DateTime.Today;
                    EventImages eventImages = new EventImages();
                    eventImages.IsActive = true;
                    eventImages.EventId = image.EventId;
                    eventImages.ImageId = imageName;
                    eventImages.Date = image.Date;
                    eventImages.Description = image.Description;
                    eventImages.EmployeeId = image.EmployeeId;
                    eventImages.Caption = image.Caption;
                    var text = _context.Add(eventImages);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<EventImages> GetImages( int eventId)
        {
            try
            {
              //  var text = _context.EventImages.Where( e =>e.IsActive==true && e.EventId == eventId).ToList();
                
                var images = (from i in _context.EventImages
                                join em in _context.Employees on i.EmployeeId equals em.Id
                                where (i.IsActive == true && i.EventId == eventId)


                                select new EventImages
                                {
                                    Author = em.EmpName,
                                    Caption = i.Caption,
                                    Date = i.Date,
                                    Description = i.Description,
                                    EmployeeId = i.EmployeeId,
                                    EventId = i.EventId,
                                    ImageId = i.ImageId,
                                    IsActive = i.IsActive


                                }).ToList();
                return images;
            }
            catch
            {
                return null;
            }
        }
        public List<Event> GetAllEvent()
        {
            var events = _context.Events.OrderByDescending(x => x.StartDate).ToList();
            return events;
        }

        public Event GetEvent(int id)
        {
            var events = _context.Events
                .Where(e => e.Id == id)
                .FirstOrDefault();
            return events;
        }

        public Boolean AddComment(Comment comnt)
        {
            try
            {
                if (comnt.CommentIn != null)
                {
                    DateTime Time = DateTime.Now;
                    comnt.CommentTime = Time;
                    comnt.isActive = true;

                    _context.Comments.Add(comnt);
                    _context.SaveChanges();

                    return true;
                }

                else
                    return false;

            }
            catch
            {
                return false;
            }
        }



        public Boolean EditComment(Comment comnt)
        {
            try
            {
                if (comnt.CommentIn != null)
                {
                    DateTime Time = DateTime.Now;
                    comnt.CommentTime = Time;
                    comnt.isActive = true;

                    _context.Comments.Add(comnt);
                    _context.SaveChanges();

                    return true;
                }

                else
                    return false;

            }
            catch
            {
                return false;
            }
        }




        public IEnumerable<ViewEmployeeforcomment> GetComments(int id)
        {
            /* var cmnt = _context.Comments

               .ToList();
             return cmnt;*/

            var comments = (from cm in _context.Comments
                            join em in _context.Employees on cm.EmployeeId equals em.Id
                            where (cm.isActive== true && cm.EventId == id)


                            select new ViewEmployeeforcomment
                            {
                                EmpId = em.Id,
                                CommentTime = cm.CommentTime,
                                EmpName = em.EmpName,
                                CommentIn = cm.CommentIn,
                                EmpProfilePicture = em.EmpProfilePicture,
                                CommentId = cm.CommentId,
                         

                             }).ToList();



            return comments;

        }

        public Boolean Delete(string id)
        {

            try
            {
                var deleteimg = _context.EventImages.Where(c =>  c.ImageId == id)
                .FirstOrDefault();
                deleteimg.IsActive = false;
                _context.Entry(deleteimg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Boolean Deletecomment(int id)
        {

            try
            {
                var deletecmnt = _context.Comments.Where(c => c.CommentId == id)
                .FirstOrDefault();
                deletecmnt.isActive = false;
                _context.Entry(deletecmnt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

    }

    
}
