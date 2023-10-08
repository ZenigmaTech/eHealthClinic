using eHealthClinic.Patient.Core.Query.Request;
using eHealthClinic.Patient.Core.Query.Response;
using eHealthClinic.Patient.Service.Data;
using MediatR;

namespace eHealthClinic.Patient.Service.Handler.Query
{

    public class GetPatientQueryHandler : IRequestHandler<GetPatientRequest, GetPatientResponse>
    {
        private readonly PatientDbContext _context;
        public GetPatientQueryHandler(PatientDbContext context)
        {
            _context = context;
        }

        public Task<GetPatientResponse> Handle(GetPatientRequest request, CancellationToken cancellationToken)
        {

            var patient = _context.Patient.FirstOrDefault(p => p.Id == request.Id);


            var response = new GetPatientResponse
            {
                Patient = patient == null ? null : new Core.Dto.PatientDto { Address = patient.Address, Mail = patient.Mail, Name = patient.Name, Phone = patient.Phone, Id = patient.Id },
                HasError = patient == null ? true : false,
                ErrorCode = patient == null ? 1 : 0
            };

            return Task.FromResult(response);
        }
    }
}

