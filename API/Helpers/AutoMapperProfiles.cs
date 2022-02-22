using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entity;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Attendance, attendeesDTO>().ForMember(dest => dest.studentName, opt => opt.MapFrom(src=> src.AppUser.UserName) ) ;
        }
    }
}