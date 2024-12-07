using System;
using System.Collections.Generic;

namespace MassageCentr.Models;

public partial class Massage
{
    public int MassageId { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Status { get; set; }

    public int? ReservationId { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
