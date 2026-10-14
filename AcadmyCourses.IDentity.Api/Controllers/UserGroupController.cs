using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcadmyCourses.IDentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : BaseApiController
    {
        private readonly IUserGroupService _userGroupService;
        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;  
        }

        [HttpPost("CreateUserGroup")]

        public async Task<IActionResult> CreateUserGroup([FromBody] DataUserGroupDtos data)
        {
            var result = await _userGroupService.CreateUserGroupasync(data, CancellationToken.None);
            return HandleResult(result);
        }

        [HttpPut("UpdateUserGroup/{id}")]
        public async Task<IActionResult> UpdateUserGroup([FromRoute] Guid id, [FromBody] DataUserGroupDtos data)
        {
            var result = await _userGroupService.UpdateUserGroupasync(id, data, CancellationToken.None);
            return HandleResult(result);
        }

        [HttpPost("AssignPermissionToGroup/{groupId}")]
        public async Task<IActionResult> AssignPermissionToGroup([FromRoute] Guid groupId, [FromBody] List<Guid> permissionCodes)
        {
            var result = await _userGroupService.AssignPermissionToGroupAsync(groupId, permissionCodes, CancellationToken.None);
            return HandleResult(result);
        }

        [HttpGet("GetAllUserGroups")]
        public async Task<IActionResult> GetAllUserGroups()
        {
            var result = await _userGroupService.GetAllUserGroupAsync(CancellationToken.None);
            return HandleResult(result);
        }

        [HttpGet("GetUserGroupById/{groupID}")]
        public async Task<IActionResult> GetUserGroupById([FromRoute]Guid groupID , CancellationToken ct = default)
        {
            var data = await _userGroupService.GetUserGroupById(groupID, ct);
            return HandleResult(data);
        }
    }
}
