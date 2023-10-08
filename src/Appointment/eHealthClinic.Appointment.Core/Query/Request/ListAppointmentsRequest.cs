using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Appointment.Core.Query.Response;
using MediatR;

namespace eHealthClinic.Appointment.Core.Query.Request
{
    public record ListAppointmentsRequest(int patientId) : IRequest<ListAppointmentsResponse>, IQueryRequest
    {
    }
}

