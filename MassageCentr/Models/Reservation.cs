using System;
using System.Collections.Generic;

namespace MassageCentr.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? ClientId { get; set; }

    public int? MassageId { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<Massage> Massages { get; set; } = new List<Massage>();

    public virtual Order? Order { get; set; }
}
