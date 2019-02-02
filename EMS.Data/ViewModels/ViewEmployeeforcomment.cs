using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.ViewModels
{
   public class ViewEmployeeforcomment
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }    
        public string EmpProfilePicture { get; set; }
        public Boolean IsActive { get; set; }       
        public DateTime CommentTime { get; set; }
        public string CommentIn { get; set; }
        public int CommentId { get; set; }

    }
    
}
