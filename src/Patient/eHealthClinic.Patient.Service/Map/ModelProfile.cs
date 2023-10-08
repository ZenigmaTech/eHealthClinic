using AutoMapper;
namespace eHealthClinic.Patient.Service.Map
{
	public class ModelProfile: Profile
	{
		public ModelProfile()
		{
			CreateMap<Core.Model.Patient, Core.Dto.PatientDto>();
			CreateMap<Core.Dto.PatientDto, Core.Model.Patient>();
		}
	}
}

