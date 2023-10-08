using System;
using eHealthClinic.Appointment.Core.Dto;

namespace eHealthClinic.Appointment.Core.Event
{
	public class AppointmentUpdatedEvent
    {
        public AppointmentDto Appointment { get; set; }

        public AppointmentUpdatedEvent(AppointmentDto appointment) => Appointment = appointment;
    }
}

