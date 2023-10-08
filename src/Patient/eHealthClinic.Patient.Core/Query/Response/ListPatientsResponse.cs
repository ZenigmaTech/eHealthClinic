using System;
using eHealthClinic.Core.CommandQuery.Interface;
using eHealthClinic.Patient.Core.Dto;

namespace eHealthClinic.Patient.Core.Query.Response
{
	public class ListPatientsResponse: IQueryResponse
	{
        public List<PatientDto>? Patients { get; set; }
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
    }
}

