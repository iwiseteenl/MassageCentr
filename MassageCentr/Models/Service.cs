using System;
using System.Collections.Generic;

namespace MassageCentr.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? Type { get; set; }

    public string? Price { get; set; }

    public virtual Order? Order { get; set; }
}
