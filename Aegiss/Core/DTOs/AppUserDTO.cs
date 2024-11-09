namespace Aegiss.Core.DTOs
{
    public class AppUserDTO
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateOnly? DateOfBirth { get; set; }
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime? LastUsernameDateChange { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}