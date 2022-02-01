using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
    public class Attendance
    {
      

        public int Id { get; set; }
        public DateTime attendDate  { get; set; }
        public bool attendanceStatus { get; set; }

    }
}

