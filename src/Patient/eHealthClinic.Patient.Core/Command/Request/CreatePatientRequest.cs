using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Command.Response;
using MediatR;

namespace eHealthClinic.Patient.Core.Command.Request
{
    public class CreatePatientRequest: IRequest<CreatePatientResponse>, ICommandRequest
	{
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Mail { get; set; }
        public required string Address { get; set; }
    }
}

