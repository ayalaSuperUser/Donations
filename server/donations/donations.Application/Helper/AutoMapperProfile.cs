using AutoMapper;
using donations.Application.Models;
using donations.DM.Models;

namespace donations.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DonationRequest, Donation>();
            CreateMap<DonationRequest, Donation>()
               .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                        return true;
                    }
                ));
        }
    }
}
