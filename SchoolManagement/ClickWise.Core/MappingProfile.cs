using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;

namespace ClickWise.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<StudentBasicInfo, StudentBasicInfoDTO>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<StudentDetails, StudentDetailsDTO>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<Documents, DocumentsDTO>().ReverseMap();
        }

    }
}
