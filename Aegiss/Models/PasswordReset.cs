using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class PasswordReset
{
    public long Id { get; set; }

    public long AppUserId { get; set; }

    public string ValidationToken { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;
}
