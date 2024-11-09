using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class TableMapping
{
    public long Id { get; set; }

    public string TableName { get; set; } = null!;

    public virtual ICollection<ChangeLog> ChangeLogs { get; set; } = new List<ChangeLog>();
}
