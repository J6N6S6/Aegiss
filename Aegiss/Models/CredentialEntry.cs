using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class CredentialEntry
{
    public long Id { get; set; }
    public long LocationAccessId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public virtual LocationAccess LocationAccess { get; set; } = null!;
}
