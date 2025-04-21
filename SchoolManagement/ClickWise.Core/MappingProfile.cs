using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;

namespace ClickWise.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<StudentBasicInfo, StudentBasicInfoDTO>().ReverseMap();
            CreateMap<StudentDetails, StudentDetailsDTO>().ReverseMap();
            CreateMap<Documents, DocumentsDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
          

        }

    }
}
