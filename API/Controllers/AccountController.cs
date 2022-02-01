using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entity;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController

    {
        private readonly DataContext _context;
        private readonly ITokenServices _tokenServices;
        public AccountController(DataContext context, ITokenServices tokenServices)
        {
            _context = context;
            _tokenServices = tokenServices;
        }    

        [HttpPost("register")]

        public async Task<ActionResult<AdminDto>> Register(RegisterDto registerdto){
            if(await AdminExists(registerdto.username)) return BadRequest("Username is Taken");

            using var hmac = new HMACSHA512();
            var admin = new AppAdmin
            {
                UserName = registerdto.username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.password)),
                PasswordSalt = hmac.Key
            };

            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();
            return new AdminDto() {
                username = admin.UserName,
                token = _tokenServices.createToken(admin)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<AdminDto>> login(LoginDto logindto)
        {
            var admin = await _context.Admin.SingleOrDefaultAsync(x=>x.UserName == logindto.username);
            if(admin == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(admin.PasswordSalt);
            var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.password));
            for(int i = 0; i<computedhash.Length; i++)
            {
                if(computedhash[i] != admin.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return new AdminDto{
                username = admin.UserName,
                token = _tokenServices.createToken(admin)
            };
        }
        private async Task<bool> AdminExists(string username){
            return await _context.Admin.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}