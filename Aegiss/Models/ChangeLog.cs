using System;
using System.Collections.Generic;

namespace Aegiss.Models;

public partial class ChangeLog
{
    public long Id { get; set; }

    public long TableMappingId { get; set; }

    public long Record { get; set; }

    public string ColumnName { get; set; } = null!;

    public short ChangeType { get; set; }

    public long Responsible { get; set; }

    public object? PreviousValue { get; set; }

    public object? NewValue { get; set; }

    public DateTime? ChangeTime { get; set; }

    public virtual TableMapping TableMapping { get; set; } = null!;
}
