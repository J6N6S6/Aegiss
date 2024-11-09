using Microsoft.AspNetCore.Mvc;
using Aegiss.Models;
//using System.Text;
using Microsoft.EntityFrameworkCore;
//using Konscious.Security.Cryptography;
//using System.Security.Cryptography;
//using System.Text.RegularExpressions;
using Aegiss.Core.Validators;
using Aegiss.Core.DTOs;
using Aegiss.Core.Exceptions;
using Aegiss.Core.Services;

namespace Aegiss.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AppUserDTO appUserDTO)
        {

            if (appUserDTO == null)
            {
                return BadRequest(new CustomException("Invalid user data.", 400));
            }
            
            if (string.IsNullOrWhiteSpace(appUserDTO.Username) || string.IsNullOrEmpty(appUserDTO.Username))
            {
                return BadRequest(new CustomException("Invalid username.", 400));
            }

            if (appUserDTO.Username.Length < 8)
            {
                return BadRequest(new CustomException("Username must have at least 8 characters.", 400));
            }

            if (!PasswordValidator.Validate(appUserDTO.Password))
            {
                return BadRequest(new CustomException("Incorrect password format.", 400));
            }

            if (await _context.AppUsers.AnyAsync(u => u.Username == appUserDTO.Username || u.Email == appUserDTO.Email))
            {
                return BadRequest(new CustomException("User or user e-mail already in the database.", 400));
            }

            string passwordHash = HashService.HashPassword(appUserDTO.Password);

            var user = new AppUser
            {
                Username = appUserDTO.Username,
                Email = appUserDTO.Email,
                Password = passwordHash,
                DateOfBirth = appUserDTO.DateOfBirth,
                City = appUserDTO.City,
                Name = appUserDTO.Name,
                Neighborhood = appUserDTO.Neighborhood,
                PhoneNumber = appUserDTO.PhoneNumber,
                State = appUserDTO.State,
                StreetName = appUserDTO.StreetName,
                StreetNumber = appUserDTO.StreetNumber,
                ZipCode = appUserDTO.ZipCode,
                RefreshToken = appUserDTO.RefreshToken
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Usuário: " + user.Id + " criado com sucesso.", Number = user.Id });
        }
    }
}
