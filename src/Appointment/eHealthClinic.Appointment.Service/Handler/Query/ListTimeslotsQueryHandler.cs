using AutoMapper;
using eHealthClinic.Appointment.Core.Query.Request;
using eHealthClinic.Appointment.Core.Query.Response;
using eHealthClinic.Appointment.Service.Data;
using eHealthClinic.Appointment.Service.Integration;
using MediatR;

namespace eHealthClinic.Appointment.Service.Handler.Query
{

    public class ListTimeslotsQueryHandler : IRequestHandler<ListTimeslotsRequest, ListTimeslotsResponse>
    {

        private readonly HospitalGrpcClient _hospitalGrpcClient;

        public ListTimeslotsQueryHandler(HospitalGrpcClient hospitalGrpcClient)
        {

            _hospitalGrpcClient = hospitalGrpcClient;
        }

        public async Task<ListTimeslotsResponse> Handle(ListTimeslotsRequest request, CancellationToken cancellationToken)
        {

            var timeSlots = await _hospitalGrpcClient.GetTimeSlots(request.Date, "HMS1");

            return new ListTimeslotsResponse
            {
                Timeslots = timeSlots.ToList(),
                ErrorCode = 0,
                HasError = false
            };

        }
    }
}

