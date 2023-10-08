using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Dto;
namespace eHealthClinic.Patient.Core.Command.Response
{
	public class CreatePatientResponse: ICommandResponse<PatientDto>
	{
		public PatientDto? Data { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

