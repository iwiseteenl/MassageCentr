using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MassageCentr.Models;

public partial class DiagrammContext : DbContext
{
    public DiagrammContext()
    {
    }

    public DiagrammContext(DbContextOptions<DiagrammContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Massage> Massages { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Service> Services { get; set; }
    public object Persons { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FH8E2CK\\SQLEXPRESS;Database=diagramm; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .HasColumnName("e-mail");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Massage>(entity =>
        {
            entity.ToTable("Massage");

            entity.Property(e => e.MassageId).HasColumnName("massageID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("status");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Massages)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_Massage_Reservation");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("orderID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");

            entity.HasOne(d => d.OrderNavigation).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Reservation");

            entity.HasOne(d => d.Order1).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Service");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId).HasColumnName("reservationID");
            entity.Property(e => e.ClientId).HasColumnName("clientID");
            entity.Property(e => e.EndTime)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("endTime");
            entity.Property(e => e.MassageId).HasColumnName("massageID");
            entity.Property(e => e.StartTime)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("startTime");

            entity.HasOne(d => d.Client).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Reservation_Client");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("serviceID");
            entity.Property(e => e.Price)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("price");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal object Client (int id)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
