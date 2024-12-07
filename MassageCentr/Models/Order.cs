using System;
using System.Collections.Generic;

namespace MassageCentr.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ClientId { get; set; }

    public int? ReservationId { get; set; }

    public int? ServiceId { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Service Order1 { get; set; } = null!;

    public virtual Reservation OrderNavigation { get; set; } = null!;
}
