using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Appointment.Core.Query.Response;
using MediatR;

namespace eHealthClinic.Appointment.Core.Query.Request
{
    public record GetAppointmentRequest(int Id) : IRequest<GetAppointmentResponse>, IQueryRequest;
}

