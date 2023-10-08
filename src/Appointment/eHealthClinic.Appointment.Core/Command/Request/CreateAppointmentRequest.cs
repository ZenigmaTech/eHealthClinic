using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Appointment.Core.Command.Response;
using MediatR;

namespace eHealthClinic.Appointment.Core.Command.Request
{
    public class CreateAppointmentRequest : IRequest<CreateAppointmentResponse>, ICommandRequest
	{
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public required string Timeslot { get; set; }
        public required string Reason { get; set; }
    }
}

