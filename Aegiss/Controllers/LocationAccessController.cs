using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aegiss.Models;
using Aegiss.Core.DTOs;
using Aegiss.Core.Exceptions;

namespace Aegiss.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LocationAccessController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationAccessController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{appUserId}")] //Get e Delete ou é por ID ou por Query Params
        public async Task<ActionResult<IEnumerable<LocationAccessDTO>>> GetAllLocationAccessByAppUser(long appUserId)
        {
            var locationAccesses = await _context.LocationAccesses.Where(la => la.AppUserId == appUserId).ToListAsync();

            if (!locationAccesses.Any())
            {
                return NotFound(new { message = "No accesses created for this user" });
            }

            var locationAccessDtos = locationAccesses.Select(la => new LocationAccessDTO
            {
                Id = la.Id,
                AppUserId = la.AppUserId,
                AccessName = la.AccessName,
                CreatedAt = la.CreatedAt

            }).ToList();

            return Ok(locationAccessDtos);

        }

        [HttpGet]
        public async Task<ActionResult<LocationAccessDTO>> GetLocationAccessByIDAndAppUser([FromQuery] long appUserId, [FromQuery] long locationAccessId)
        {
            var locationAcesses = await _context.LocationAccesses
                .Where(la => la.AppUserId == appUserId && la.Id == locationAccessId)
                .Select(la => new LocationAccessDTO
                {
                    Id = la.Id,
                    AppUserId = la.AppUserId,
                    AccessName = la.AccessName,
                    CreatedAt = la.CreatedAt
                })
                .ToListAsync();

            //locationAcesses = locationAcesses.SingleOrDefault(la => la.Id == locationAccessId).ToListAsync();

            if(locationAcesses.Count > 1)
            {
                return BadRequest(new CustomException("There are more than 1 location accesses withg the id " + locationAccessId, 400));
            }
            
            if (!locationAcesses.Any())
            {
                return NotFound(new CustomException("There is no location access number " + locationAccessId, 404));
            }

            return Ok(locationAcesses.SingleOrDefault());

        }


        [HttpPost] //Post e Put eu pego no body
        public async Task<IActionResult> CreateLocationAccess([FromBody] LocationAccessDTO locationAccessDTO)
        {
            if (locationAccessDTO == null)
            {
                return BadRequest(new CustomException("Invalid location access", 400));
            }

            if (locationAccessDTO.AppUserId == 0)
            {
                return BadRequest(new CustomException("Invalid appUser", 400));
            }

            if (string.IsNullOrEmpty(locationAccessDTO.AccessName))
            {
                return BadRequest(new CustomException("Invalid access name", 400));
            }

            var location = new LocationAccess
            {
                AppUserId = locationAccessDTO.AppUserId,
                AccessName = locationAccessDTO.AccessName,
                CreatedAt = DateTime.Now
            };

            _context.LocationAccesses.Add(location);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Location access " + location.Id + " successfully created", Number = location.Id });
        }
    }
}
