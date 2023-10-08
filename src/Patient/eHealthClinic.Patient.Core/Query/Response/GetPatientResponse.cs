using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Dto;

namespace eHealthClinic.Patient.Core.Query.Response
{
	public class GetPatientResponse:  IQueryResponse
	{
        public PatientDto? Patient { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

