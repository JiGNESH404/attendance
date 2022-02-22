using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class attendeesDTO
    {
        public int AppUserId { get; set; }
        public string studentName { get; set; }
        public bool attendanceStatus { get; set; }
    }
}