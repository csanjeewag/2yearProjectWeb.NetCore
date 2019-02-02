using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.ViewModels
{
    public class ViewTeamSchedule
    {
  
        public Boolean IsActive { get; set; }
        public string SchName { get; set; }
        public DateTime SchDate { get; set; }
        public List<string> teamnames { get; set; }
        public List<string> teamcaptains { get; set; }
    }
}
