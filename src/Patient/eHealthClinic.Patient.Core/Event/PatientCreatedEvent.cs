using System;
using eHealthClinic.Patient.Core.Dto;

namespace eHealthClinic.Patient.Core.Event
{
	public class PatientCreatedEvent
	{
        public PatientDto Patient { get; set; }

        public PatientCreatedEvent(PatientDto patient) => Patient = patient;
    }
}

