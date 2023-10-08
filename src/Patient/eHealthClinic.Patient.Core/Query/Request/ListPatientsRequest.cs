using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Query.Response;
using MediatR;

namespace eHealthClinic.Patient.Core.Query.Request
{
    public class ListPatientsRequest : IRequest<ListPatientsResponse>, IQueryRequest
    {
    }
}

