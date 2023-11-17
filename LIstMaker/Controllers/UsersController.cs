using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIstMaker.Data;
using LIstMaker.Models;
using LIstMaker.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace LIstMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LIstMakerContext _context;

        public UsersController(LIstMakerContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //PUT: api/users/login
        [HttpPut("login")]
        public async Task<ActionResult<User>> LogIn(LogInDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            if(user == null)
            {
                return Unauthorized("Username does not exist!");
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var compuateHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password!));
            for(int i = 0;  i < compuateHash.Length; i++)
            {
                if (compuateHash[i] != user.PasswordHash[i]) return Unauthorized("Bad Password!");
            }
            return user;
        }
        //PUT: api/users/resetPassword
        [HttpPut("resetPassword")]
        public async Task<ActionResult<User>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == resetPasswordDto.UserName);
            if (user == null) { return Unauthorized("Invalid Username"); }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var compuateHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resetPasswordDto.CurrentPassword!));
            for(int i = 0; i < compuateHash.Length; i++)
            {
                if (compuateHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password!");
            }
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resetPasswordDto.NewPassword!));

            await _context.SaveChangesAsync();
            return user;
        }
        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        //POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> RegisterUser(RegisterDto registerDto)
        {
            if ( await UserExists(registerDto.UserName!))
            {
                return BadRequest("Username Is Taken!");
            }
            using var hmac = new HMACSHA512();
            User user = new User {
                UserName = registerDto.UserName!.ToLower(),
                Email = registerDto.Email!,
                isAdmin = registerDto.isAdmin!,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password!)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        private async Task<bool> UserExists(string userName)
        {
            bool exists = await _context.Users.AnyAsync(x => x.UserName == userName);
            return exists;
        }
    }
}
