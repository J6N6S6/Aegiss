namespace Aegiss.Core.DTOs
{
    public class LocationAccessDTO
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public string AccessName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
