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

    }
}
