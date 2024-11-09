namespace Aegiss.Core.DTOs
{
    public class CredentialEntryDTO
    {
        public long Id { get; set; }
        public long LocationAccessId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
