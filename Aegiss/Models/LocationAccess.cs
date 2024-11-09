using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class LocationAccess
{
    public long Id { get; set; }
    public long AppUserId { get; set; }
    public string AccessName { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public virtual AppUser AppUser { get; set; } = null!;
    public virtual ICollection<CredentialEntry> CredentialEntries { get; set; } = new List<CredentialEntry>();
}
