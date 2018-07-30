using AutoMapper;
using NetCoursework.Dtos;
using NetCoursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCoursework.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<RegisteredUsers, RegisteredUsersDto>();
            Mapper.CreateMap<RegisteredUsersDto, RegisteredUsers>();

            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<EventDto, Event>();
        }
    }
}