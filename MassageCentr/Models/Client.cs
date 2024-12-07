using System;
using System.Collections.Generic;

namespace MassageCentr.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Name { get; set; }

    public string? EMail { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
