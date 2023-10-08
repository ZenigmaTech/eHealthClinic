using System;
using eHealthClinic.Appointment.Core.Dto;

namespace eHealthClinic.Appointment.Core.Event
{
	public class AppointmentCreatedEvent
    {
        public AppointmentDto Appointment { get; set; }

        public AppointmentCreatedEvent(AppointmentDto appointment) => Appointment = appointment;
    }
}

