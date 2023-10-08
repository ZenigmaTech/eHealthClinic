using System;
using eHealthClinic.Core.Event.Interface;
using eHealthClinic.Patient.Core.Command.Request;
using eHealthClinic.Patient.Core.Command.Response;
using eHealthClinic.Patient.Core.Event;
using eHealthClinic.Patient.Service.Data;
using MediatR;
using Newtonsoft.Json;

namespace eHealthClinic.Patient.Service.Handler.Command
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientRequest, CreatePatientResponse>
    {
        private readonly PatientDbContext _context;
        private readonly IEventProducer _producer;
        public CreatePatientCommandHandler(PatientDbContext context, IEventProducer producer)
        {
            _context = context;
            _producer = producer;
        }

        public async Task<CreatePatientResponse> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
        {
            var patient = new Core.Model.Patient
            {
                Name = request.Name,
                Phone = request.Phone,
                Mail = request.Mail,
                Address = request.Address,
                UserName = request.Mail,
                Password = "password"
            };
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();

            var patientDto = new Core.Dto.PatientDto { Id = patient.Id, Address = patient.Address, Mail = patient.Mail, Name = patient.Name, Phone = patient.Name };
            // Raise an event
            var patientCreatedEvent = new PatientCreatedEvent(patientDto);
            await _producer.ProduceAsync("patient-created", JsonConvert.SerializeObject(patientCreatedEvent));

            return new CreatePatientResponse
            {
                Data = patientDto,
                HasError = false,
                ErrorCode = 0
            };
        }
    }
}

