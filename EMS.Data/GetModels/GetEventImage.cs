using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
   public class GetEventImage
    {
        public List<IFormFile> Image { get; set; }
        public int EventId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public int Author { get; set; }
    }
}
