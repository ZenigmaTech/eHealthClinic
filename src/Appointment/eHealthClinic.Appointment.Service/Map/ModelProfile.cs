using AutoMapper;
namespace eHealthClinic.Appointment.Service.Map
{
	public class ModelProfile: Profile
	{
		public ModelProfile()
		{
			CreateMap<Core.Model.Appointment, Core.Dto.AppointmentDto>();
			CreateMap<Core.Dto.AppointmentDto, Core.Model.Appointment>();
		}
	}
}

