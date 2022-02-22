using API.Data;
using API.DTO;
using API.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync();
        }
        [HttpGet("class/{classId}")]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetClassUsers([FromRoute]int classId){
            Console.WriteLine("classId = "+ classId);
            var students = _context.Users.Where(x=> x.studentClassId == classId);
            Console.WriteLine(students.ToList());
            return await students.ToListAsync();
        }
        [Authorize]
         [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUser(int id){

            return await _context.Users.FindAsync(id);
        }
        /*  [Authorize]
         [HttpGet()]
        public async Task <ActionResult<AppUser[]>> GetClassUsers([FromQuery] int classId){

            return await  _context.Users.Where(x=>x.studentClassId == classId).ToListAsync();
        } */
        [HttpPost("new")]
        public async Task<ActionResult<newStudentdto>> AddNewStudent([FromBody]  newStudentdto newStudent){


            var student = new AppUser{
                UserName = newStudent.studentName,
                studentClassId = newStudent.classId
            };


             _context.Users.Add(student);
             await _context.SaveChangesAsync();

             return new newStudentdto(){
                 studentName = student.UserName,
                 classId = student.studentClassId
             };

        }
    
    }
}