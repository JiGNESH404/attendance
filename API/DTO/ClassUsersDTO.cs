using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class ClassUsersDTO
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}