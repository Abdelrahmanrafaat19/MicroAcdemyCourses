using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using AcadmyCourses.IDentity.Domain.UserGroup;
using AcadmyCourses.IDentity.Inftustucture.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Profiles
{
    public class UserGroupProfiel : Profile
    {
        public UserGroupProfiel()
        {
            CreateMap<UserGroup , DataUserGroupDtos>().ReverseMap();
            CreateMap<UserGroup, CreateUserGroupDtos>().ReverseMap();
            CreateMap<UserEntity , UserEntityDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupAndUser>().ReverseMap()   ;
        }

    }
}
