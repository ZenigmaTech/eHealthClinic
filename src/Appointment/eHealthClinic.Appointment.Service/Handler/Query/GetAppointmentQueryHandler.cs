using eHealthClinic.Appointment.Core.Query.Request;
using eHealthClinic.Appointment.Core.Query.Response;
using eHealthClinic.Appointment.Service.Data;
using MediatR;
using AutoMapper;

namespace eHealthClinic.Appointment.Service.Handler.Query
{

    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentRequest, GetAppointmentResponse>
    {
        private readonly AppointmentDbContext _context;
        private readonly IMapper _mapper;
        public GetAppointmentQueryHandler(AppointmentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetAppointmentResponse> Handle(GetAppointmentRequest request, CancellationToken cancellationToken)
        {

            var appointment = _context.Appointment.FirstOrDefault(p => p.Id == request.Id);


            var response = new GetAppointmentResponse
            {
                Appointment = appointment == null ? null : _mapper.Map<Core.Dto.AppointmentDto>(appointment),
                HasError = appointment == null ? true : false,
                ErrorCode = appointment == null ? 1 : 0
            };

            return Task.FromResult(response);
        }
    }
}

