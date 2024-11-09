using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Konscious.Security.Cryptography;
using Aegiss.Core.Services;
using Aegiss.Core.DTOs;
using Aegiss.Models;
using Microsoft.AspNetCore.Identity;
using Azure.Identity;


namespace Aegiss.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public IActionResult Login([FromBody] Auth login)
        {
            if (login.username == null)
            {
                return BadRequest("USERNAME KKKKKKKKKKKKKKKK");
            }
            if (login.password == null)
            {
                return BadRequest("SENHA KKKKKKKKKKKKKKKKK");
            }

            var userExists = _context.AppUsers.FirstOrDefault(u => u.Username == login.username);

            if (userExists == null)
            {
                return BadRequest("User does not exist.");
            }

            bool correctPassword = HashService.VerifyPassword(login.password, userExists.Password);

            if (!correctPassword)
            {
                return BadRequest("Wrong password.");
            }

            var _tokenGenerator = new TokenGenerator();
            var token = _tokenGenerator.GenerateToken(userExists.Id);

            return Ok( new {token});
        }
    }
}
