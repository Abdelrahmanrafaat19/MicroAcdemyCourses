

using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using Microsoft.AspNetCore.Mvc;

namespace AcadmyCourses.IDentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : BaseApiController
    {
        private readonly IPermissionServices _permissionServices;
        public PermissionController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        [HttpPost("CreatePermission")]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDto data)
        {
            var result = await _permissionServices.CreatePermissionAsync(data, CancellationToken.None);
            return HandleResult(result);
        }
        [HttpGet("GetAllPermissions")]
        public async Task<IActionResult> GetAllPermissions()
        {
            var result = await _permissionServices.GetAllPermissionAsync(CancellationToken.None);
            return HandleResult(result);
        }
        [HttpGet("GetPermissionByCode/{code}")]
        public async Task<IActionResult> GetPermissionByCode([FromRoute] string code)
        {
            var result = await _permissionServices.GetPermissionByCode(code, CancellationToken.None);
            return HandleResult(result);
        }
    }
}
