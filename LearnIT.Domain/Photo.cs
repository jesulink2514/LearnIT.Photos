using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnIT.Domain
{
    public class Photo
    {
        public Photo()
        {
            Creation = DateTime.Now;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Creation { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
        public string MimeType { get; set; }
        public int DaysFromCreation
        {
            get
            {
                return (int)(DateTime.Now - Creation).TotalDays;
            }
        }
    }
}
