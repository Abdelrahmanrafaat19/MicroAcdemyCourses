using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using AcadmyCourses.IDentity.Domain.UserGroup;
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
            CreateMap<UserGroup , CreateUserGroupDtos>().ReverseMap();
        }

    }
}
