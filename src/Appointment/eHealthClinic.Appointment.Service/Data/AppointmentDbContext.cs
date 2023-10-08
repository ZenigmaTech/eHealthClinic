using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eHealthClinic.Appointment.Service.Data
{
	public class AppointmentDbContext : DbContext
	{
		public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
        }

        public DbSet<Core.Model.Appointment> Appointment { get; set; }
    }
}

