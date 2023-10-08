using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Appointment.Core.Dto;
namespace eHealthClinic.Appointment.Core.Command.Response
{
	public class CreateAppointmentResponse : ICommandResponse<AppointmentDto>
	{
		public AppointmentDto? Data { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

