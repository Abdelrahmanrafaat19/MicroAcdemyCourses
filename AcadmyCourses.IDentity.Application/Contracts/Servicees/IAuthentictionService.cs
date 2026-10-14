using AcadmyCourses.IDentity.Application.Dtos.CreateUserDto;
using AcadmyCourses.IDentity.Application.Dtos.LoginDto;
using AcadmyCourses.IDentity.Application.Dtos.UserEntityDto;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Contracts.Servicees
{
    public interface IAuthentictionService
    {
        Task<Result<ReturnedUserCreation>> UserResgistrationAsync(CreateUserDto data , CancellationToken ct);
        Task<Result<bool>> UpdateDataUser(string email, UpdateUserData data, CancellationToken ct);
        Task<Result<ProfileDataDto>> ProfileDataAsync(string userID, CancellationToken ct);
        Task<Result<string>> ActiveAndDeactineAsync(string userID, CancellationToken ct);
        Task<Result<ReturnedLoginDto>> LoginAsync(InPutLoginDto data, CancellationToken ct);
        Task<Result<bool>> UpdateUserGroupAsync(Guid UserID, Guid GroupID, CancellationToken ct);
    }
}
