using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class EmailReset
{
    public long Id { get; set; }

    public long AppUserId { get; set; }

    public string NewEmail { get; set; } = null!;

    public string ValidationToken { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;
}
