using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Query.Response;
using MediatR;

namespace eHealthClinic.Patient.Core.Query.Request
{
    public record LoginPatientRequest(string userName, string password) : IRequest<LoginPatientResponse>, IQueryRequest;
}

