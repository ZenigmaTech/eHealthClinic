using System;
using eHealthClinic.Core.Event.Interface;
using eHealthClinic.Appointment.Core.Command.Request;
using eHealthClinic.Appointment.Core.Command.Response;
using eHealthClinic.Appointment.Core.Event;
using eHealthClinic.Appointment.Service.Data;
using MediatR;
using Newtonsoft.Json;
using AutoMapper;
using eHealthClinic.Appointment.Service.Integration;
using Microsoft.Extensions.Logging;

namespace eHealthClinic.Appointment.Service.Handler.Command
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
    {
        private readonly AppointmentDbContext _context;
        private readonly HospitalGrpcClient _hospitalGrpcClient;
        private readonly IEventProducer _producer;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAppointmentCommandHandler> _logger;
        public CreateAppointmentCommandHandler(ILogger<CreateAppointmentCommandHandler> logger, AppointmentDbContext context, IEventProducer producer, IMapper mapper, HospitalGrpcClient hospitalGrpcClient)
        {
            _context = context;
            _producer = producer;
            _mapper = mapper;
            _hospitalGrpcClient = hospitalGrpcClient;
            _logger = logger;
        }

        public AppointmentDbContext Get_context()
        {
            return _context;
        }

        public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
        {
            var appointment = new Core.Model.Appointment
            {
                Date = request.Date,
                PatientId = request.PatientId,
                Reason = request.Reason,
                Timeslot = request.Timeslot
            };

            var timeSlots = await _hospitalGrpcClient.GetTimeSlots(appointment.Date.ToLongDateString(), "HMS1");
            _logger.LogInformation($"Here is the available timeslots: {JsonConvert.SerializeObject(timeSlots)}");
            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            var appointmentDto = _mapper.Map<Core.Dto.AppointmentDto>(appointment);
            // Raise an event
            var AppointmentCreatedEvent = new AppointmentCreatedEvent(appointmentDto);
            await _producer.ProduceAsync("appointment-created", JsonConvert.SerializeObject(AppointmentCreatedEvent));

            return new CreateAppointmentResponse
            {
                Data = appointmentDto,
                HasError = false,
                ErrorCode = 0
            };
        }

    }
}

