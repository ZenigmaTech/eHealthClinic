﻿using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Appointment.Core.Dto;

namespace eHealthClinic.Appointment.Core.Query.Response
{
	public class ListAppointmentsResponse : IQueryResponse
	{
        public List<AppointmentDto>? Appointments { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

