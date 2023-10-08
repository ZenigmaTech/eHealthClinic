using Grpc.Core;

namespace Integration.Services;

public class TimeSlotServiceImpl : TimeSlotService.TimeSlotServiceBase
{
    private readonly ILogger<TimeSlotServiceImpl> _logger;

    public TimeSlotServiceImpl(ILogger<TimeSlotServiceImpl> logger)
    {
        _logger = logger;
    }

    public override Task<TimeSlotResponse> GetAvailableTimeSlots(TimeSlotRequest request, ServerCallContext context)
    {
        // Here you'd typically query your database to get available slots for the given hospitalId and date.
        // For the sake of this example, let's return some hardcoded slots:

        var response = new TimeSlotResponse
        {
            Timeslots = { new List<string> { "09:00", "09:30", "10:00", "10:30" } }
        };

        return Task.FromResult(response);
    }
}


