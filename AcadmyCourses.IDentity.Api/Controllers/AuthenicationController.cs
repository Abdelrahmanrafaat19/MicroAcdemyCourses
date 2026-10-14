using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.CreateUserDto;
using AcadmyCourses.IDentity.Application.Dtos.LoginDto;
using AcadmyCourses.IDentity.Application.Dtos.UserEntityDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcadmyCourses.IDentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenicationController : BaseApiController
    {
        private readonly IAuthentictionService _authenticationService;
        public AuthenicationController(IAuthentictionService authenticationService)
        {
            this._authenticationService = authenticationService;
            
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto userDto, CancellationToken ct = default)
        {
            var result = await _authenticationService.UserResgistrationAsync(userDto, ct);
            return HandleResult(result);
        }

        [HttpPost("UpdateUserData")]
        [Authorize]

        public async Task<IActionResult> UpdateDataUser([FromBody] UpdateUserData data , CancellationToken ct=default!)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _authenticationService.UpdateDataUser(email! , data ,ct);
            return HandleResult(result);
        }
        [HttpPost("ProfileData")]
        [Authorize]
        public async Task<IActionResult> ProfileData( CancellationToken ct = default!)
        {
            var UserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _authenticationService.ProfileDataAsync(UserID!, ct);
            return HandleResult(result);
        }

        [HttpPost("ActiveAndDeActive")]
        [Authorize]
        public async Task<IActionResult> ActiveAndDeActive(CancellationToken ct = default!)
        {
            var UserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _authenticationService.ActiveAndDeactineAsync(UserID!, ct);
            return HandleResult(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] InPutLoginDto data , CancellationToken ct = default!)
        {
            var result = await _authenticationService.LoginAsync(data, ct);
            return HandleResult(result);
        }
        [HttpPost("UpdateUserGroup")]
        public async Task<IActionResult> UpdateUserGroup([FromBody] UpdateUserGroupDto data , CancellationToken ct = default!)
        {
            var result = await _authenticationService.UpdateUserGroupAsync(GroupID: data.GroupID, UserID: data.UserID, ct: ct);
            return HandleResult(result);
        }
    }
}
