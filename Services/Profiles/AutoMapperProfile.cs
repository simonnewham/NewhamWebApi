using AutoMapper;
using DataLayer.Data;

namespace Models.Profiles
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<FAQ, FAQDetailsDto>();
		}
	}
}

