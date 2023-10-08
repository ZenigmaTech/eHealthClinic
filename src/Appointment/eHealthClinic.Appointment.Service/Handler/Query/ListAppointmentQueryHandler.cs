using AutoMapper;
using eHealthClinic.Appointment.Core.Dto;
using eHealthClinic.Appointment.Core.Query.Request;
using eHealthClinic.Appointment.Core.Query.Response;
using eHealthClinic.Appointment.Service.Data;
using MediatR;

namespace eHealthClinic.Appointment.Service.Handler.Query
{

    public class ListAppointmentQueryHandler : IRequestHandler<ListAppointmentsRequest, ListAppointmentsResponse>
    {
        private readonly AppointmentDbContext _context;
        private readonly IMapper _mapper;
        public ListAppointmentQueryHandler(AppointmentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ListAppointmentsResponse> Handle(ListAppointmentsRequest request, CancellationToken cancellationToken)
        {

            var Appointments = _context.Appointment.Where(a => a.PatientId == request.patientId).ToList();

            var response = new ListAppointmentsResponse
            {
                Appointments = _mapper.Map<List<AppointmentDto>>(Appointments)
            };

            return Task.FromResult(response);

        }
    }
}

