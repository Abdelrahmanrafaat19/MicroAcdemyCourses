using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using AcadmyCourses.IDentity.Inftustucture.Entities;
using AutoMapper;


namespace AcadmyCourses.IDentity.Inftustucture.Profiles
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<Permission ,CreatePermissionDto>().ReverseMap();
            CreateMap<Permission ,PermissionDto>().ReverseMap();
        }
    }
}
