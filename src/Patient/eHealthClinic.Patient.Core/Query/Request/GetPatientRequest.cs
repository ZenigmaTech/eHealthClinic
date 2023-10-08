using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Query.Response;
using MediatR;

namespace eHealthClinic.Patient.Core.Query.Request
{
    public record GetPatientRequest(int Id) : IRequest<GetPatientResponse>, IQueryRequest;
    }

