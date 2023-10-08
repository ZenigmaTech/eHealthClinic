using eHealthClinic.Core.CommandQuery.Interface;

namespace eHealthClinic.Appointment.Core.Query.Response
{
    public class ListTimeslotsResponse : IQueryResponse
	{
        public List<string>? Timeslots { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

