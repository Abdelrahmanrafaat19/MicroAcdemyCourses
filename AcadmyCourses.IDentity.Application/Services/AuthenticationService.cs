using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.CreateUserDto;
using AcadmyCourses.IDentity.Application.Dtos.LoginDto;
using AcadmyCourses.IDentity.Application.Dtos.UserEntityDto;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Services
{
    public class AuthenticationService : IAuthentictionService
    {
        public readonly IIdentityService _identityService;
        public AuthenticationService(IIdentityService identityService)
        {
            this._identityService = identityService;

        }

        public async Task<Result<string>> ActiveAndDeactineAsync(string userID, CancellationToken ct)
        {
            return await _identityService.ActiveAndDeactineAsync(userID , ct);
        }

        public async Task<Result<ReturnedLoginDto>> LoginAsync(InPutLoginDto data, CancellationToken ct)
        {
            return await _identityService.LoginAsync(data , ct);
        }

        public async Task<Result<ProfileDataDto>> ProfileDataAsync(string userID, CancellationToken ct)
        {
            return await _identityService.ProfileDataAsync(userID, ct);
        }

        public async Task<Result<bool>> UpdateDataUser(string email, UpdateUserData data, CancellationToken ct )
        {
            return await _identityService.UpdateDataUser(email, data, ct);
        }

        public async Task<Result<bool>> UpdateUserGroupAsync(Guid UserID, Guid GroupID, CancellationToken ct)
        {
            return await _identityService.UpdateUserGroupAsync(UserID, GroupID, ct);
        }

        public async Task<Result<ReturnedUserCreation>> UserResgistrationAsync(CreateUserDto data, CancellationToken ct=default)
        {
            return await _identityService.CreateUserAsync(data, ct);
        }
    }
}
