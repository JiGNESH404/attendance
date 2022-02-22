using API.Data;
using API.DTO;
using API.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class attendanceController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public attendanceController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
         [HttpPost("class/{classId}")]
         public async Task markAttendance(int classId, [FromBody] Attendance[] list )
         {
             foreach(var listItem in list)
             {
                 _context.Attendances.Add(listItem);
             }
             
             await _context.SaveChangesAsync();


         }

         [HttpGet("class/{classId}")]
        public async Task<ActionResult<IEnumerable<attendeesDTO>>> GetAttendance([FromRoute] int classId, [FromQuery] string attendDate)
        {
            
            Console.Write(attendDate+"  "+ classId);
            var ans =  await _context.Attendances.Where(y=> y.attendDate.CompareTo(attendDate)==0 && y.SudentClassId==classId).Include(u => u.AppUser).ToListAsync();
            var attendees =  _mapper.Map<IEnumerable<attendeesDTO>>(ans);
            return Ok(attendees);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetStudentAttendance([FromRoute] int userid)
        {
            return await _context.Attendances.Where(x => x.AppUserId == userid).ToListAsync();
        }

        [HttpGet("for")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance([FromQuery] string epoch)
        {

           
            return await _context.Attendances.Where(x => x.attendDate == epoch).ToListAsync();
        }
        


        [HttpDelete("{id}")]

        public async Task Delete([FromQuery] int id)
        {

            var row = _context.Attendances.SingleOrDefault(x => x.Id == id);
            if (row != null)
            {
                _context.Attendances.Remove(row);
            }


            await _context.SaveChangesAsync();
        }


    }
}