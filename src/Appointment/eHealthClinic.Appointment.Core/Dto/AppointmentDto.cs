using System;
namespace eHealthClinic.Appointment.Core.Dto
{
	public class AppointmentDto
    {
		public int Id { get; set; }
		public int PatientId  { get; set; }
		public DateTime Date { get; set; }
		public required string Timeslot { get; set; }
		public required string Reason { get; set; }
	}
}

