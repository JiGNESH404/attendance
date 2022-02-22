using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class AttendanceDTO
    {
        public int studentId { get; set; }
        public string studentName{get; set;}
        public bool status { get; set; }
    }
}