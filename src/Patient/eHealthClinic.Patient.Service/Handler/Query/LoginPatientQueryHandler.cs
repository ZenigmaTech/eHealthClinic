using eHealthClinic.Patient.Core.Query.Request;
using eHealthClinic.Patient.Core.Query.Response;
using eHealthClinic.Patient.Service.Data;
using MediatR;

namespace eHealthClinic.Patient.Service.Handler.Query
{

    public class LoginPatientQueryHandler : IRequestHandler<LoginPatientRequest, LoginPatientResponse>
    {
        private readonly PatientDbContext _context;
        public LoginPatientQueryHandler(PatientDbContext context)
        {
            _context = context;
        }

        public Task<LoginPatientResponse> Handle(LoginPatientRequest request, CancellationToken cancellationToken)
        {

            var patient = _context.Patient.FirstOrDefault(p => p.UserName == request.userName && p.Password == request.password);


            var response = new LoginPatientResponse
            {
                Patient = patient == null ? null : new Core.Dto.PatientDto { Address = patient.Address, Mail = patient.Mail, Name = patient.Name, Phone = patient.Phone, Id = patient.Id },
                HasError = patient == null ? true : false,
                ErrorCode = patient == null ? 1 : 0
            };

            return Task.FromResult(response);
        }
    }
}

