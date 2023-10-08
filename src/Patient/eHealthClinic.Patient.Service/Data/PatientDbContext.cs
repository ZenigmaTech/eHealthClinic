using Microsoft.EntityFrameworkCore;

namespace eHealthClinic.Patient.Service.Data
{
	public class PatientDbContext: DbContext
	{
		public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        public DbSet<Core.Model.Patient> Patient { get; set; }
    }
}

