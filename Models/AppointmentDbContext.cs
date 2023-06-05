using System;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{

public class AppointmentDbContext : DbContext

{

    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

    public DbSet<Appointment>? Appoinments { get; set; }

}
}