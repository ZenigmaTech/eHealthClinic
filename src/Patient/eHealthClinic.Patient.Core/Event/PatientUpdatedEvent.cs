using System;
using eHealthClinic.Patient.Core.Dto;

namespace eHealthClinic.Patient.Core.Event
{
	public class PatientUpdatedEvent
	{
        public PatientDto Patient { get; set; }

        public PatientUpdatedEvent(PatientDto patient) => Patient = patient;
    }
}

