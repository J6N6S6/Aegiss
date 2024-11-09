using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class UserCharacteristic
{
    public long Id { get; set; }

    public long AppUserId { get; set; }

    public short ImageTypeId { get; set; }

    public byte[] CharacteristicsValue { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual AppUser AppUser { get; set; } = null!;

    public virtual ImageType ImageType { get; set; } = null!;
}
