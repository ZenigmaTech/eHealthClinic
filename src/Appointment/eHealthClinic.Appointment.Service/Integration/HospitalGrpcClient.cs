using System;
using Grpc.Net.Client;
using Integration;

namespace eHealthClinic.Appointment.Service.Integration
{
	public class HospitalGrpcClient
	{
		private readonly TimeSlotService.TimeSlotServiceClient _client;

		public HospitalGrpcClient(string url)
		{
            AppContext.SetSwitch(
    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            GrpcChannel channel = GrpcChannel.ForAddress(url);
			_client = new TimeSlotService.TimeSlotServiceClient(channel);
        }

		public async Task<List<string>> GetTimeSlots(string date, string hospitalId)
		{
			var result = await _client.GetAvailableTimeSlotsAsync(new TimeSlotRequest { Date = date, HospitalId = hospitalId }, null);
			return result.Timeslots.ToList();
		}

	}
}

