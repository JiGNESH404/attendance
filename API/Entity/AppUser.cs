using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entity
{
  
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public studentClass studentClass {get; set;}
         public int studentClassId { get; set; }

        
    }
}