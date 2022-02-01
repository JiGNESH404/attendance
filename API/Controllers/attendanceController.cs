using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class attendanceController : BaseApiController
    {
         private readonly DataContext _context;

        public attendanceController(DataContext context)
        {
            _context = context;
        }
         [HttpPost("markattend")]
        public async Task  markAttendance( DateTime date, bool status ){

           _context.Attendances.Add(
                new Attendance{
                attendDate = date,
                attendanceStatus = status
            });
            await _context.SaveChangesAsync();

            
        }

         [HttpGet]
        public async Task <ActionResult<IEnumerable<Attendance>>> GetUsers(){
            return await _context.Attendances.ToListAsync();
        }

        [HttpDelete("{id}")]

        public async Task Delete([FromQuery] int id){
            
           var row = _context.Attendances.SingleOrDefault(x => x.Id == id);
           if(row != null)
           {
               _context.Attendances.Remove(row);
           }
           

            await _context.SaveChangesAsync();
        }

       
    }
}