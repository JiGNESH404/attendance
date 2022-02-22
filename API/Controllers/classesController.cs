using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class classesController : BaseApiController
    {
        private readonly DataContext _context;

        public classesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<studentClass>> GetClass()
        {
            return await _context.studentClass.ToListAsync();
        }
        [HttpPost("new")]
        public async Task addClass(newclassDto newClass)
        {
            var classNew = new studentClass
            {
                className = newClass.className.ToLower()
            };
            _context.studentClass.Add(classNew);

            await _context.SaveChangesAsync();
        }
    }
}