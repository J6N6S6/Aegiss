using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aegiss.Models;
using Aegiss.Core.DTOs;
using Aegiss.Core.Exceptions;
using Aegiss.Core.Services;

namespace Aegiss.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialEntryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CredentialEntryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<CredentialEntryDTO>> GetCredentialsByAllId([FromQuery] long locationAccessId, [FromQuery] long appUserId)
        {
            if (locationAccessId == 0 || appUserId == 0)
            {
                return BadRequest(new CustomException("There is no location access or app user in the request", 400));
            }

            var credentialLocation = await _context.LocationAccesses
                .Where(la => la.AppUserId == appUserId && la.Id == locationAccessId)
                .ToListAsync();

            if (!credentialLocation.Any())
            {
                return NotFound(new CustomException("The location access does not belong to the user requested", 400));
            }

            var credentials = await _context.CredentialEntries
                .Where(ce => ce.LocationAccessId == locationAccessId)
                .Select(ce => new CredentialEntry
                {
                    Id = ce.Id,
                    LocationAccessId = ce.LocationAccessId,
                    Username = ce.Username,
                    Password = ce.Password
                })
                .ToListAsync();

            return Ok(credentials.LastOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCredentialEntry([FromBody] CredentialEntryDTO credentialEntry)
        {
            if (credentialEntry == null)
            {
                return BadRequest(new CustomException("Invalid credentials data", 400));
            }

            if (credentialEntry.LocationAccessId == 0 || credentialEntry.LocationAccessId == null)
            {
                return BadRequest(new CustomException("Invalid location access", 400));
            }

            if (string.IsNullOrEmpty(credentialEntry.Username) || string.IsNullOrEmpty(credentialEntry.Password))
            {
                return BadRequest(new CustomException("Invalid username or password", 400));
            }

            var credentials = new CredentialEntry
            {
                LocationAccessId = credentialEntry.LocationAccessId,
                Username = credentialEntry.Username,
                Password = HashService.HashPassword(credentialEntry.Password),
                CreatedAt = DateTime.Now

            };

            _context.CredentialEntries.Add(credentials);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Credentials " + credentials.Id + " successfully created", Number = credentials.Id });
        }
    }
}
