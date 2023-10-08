using AutoMapper;
using eHealthClinic.Patient.Core.Dto;
using eHealthClinic.Patient.Core.Query.Request;
using eHealthClinic.Patient.Core.Query.Response;
using eHealthClinic.Patient.Service.Data;
using MediatR;

namespace eHealthClinic.Patient.Service.Handler.Query
{

    public class ListPatientQueryHandler : IRequestHandler<ListPatientsRequest, ListPatientsResponse>
    {
        private readonly PatientDbContext _context;
        private readonly IMapper _mapper;
        public ListPatientQueryHandler(PatientDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ListPatientsResponse> Handle(ListPatientsRequest request, CancellationToken cancellationToken)
        {

            var patients = _context.Patient.ToList();

            var response = new ListPatientsResponse
            {
                Patients = _mapper.Map<List<PatientDto>>(patients)
            };

            return Task.FromResult(response);

        }
    }
}

