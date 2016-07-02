using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnIT.Models.Photos
{
    public class UploadViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
    }
}