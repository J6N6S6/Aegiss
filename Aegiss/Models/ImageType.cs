using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class ImageType
{
    public short Id { get; set; }

    public string TypeDescription { get; set; } = null!;

    public virtual ICollection<UserCharacteristic> UserCharacteristics { get; set; } = new List<UserCharacteristic>();
}
