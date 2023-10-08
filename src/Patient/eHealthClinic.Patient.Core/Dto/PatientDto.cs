using System;
namespace eHealthClinic.Patient.Core.Dto
{
	public class PatientDto
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Phone { get; set; }
		public required string Mail { get; set; }
		public required string Address { get; set; }
	}
}

