using AcadmyCourses.IDentity.Application.Contracts.Repositories;
using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using StockManagment.Application.common;

namespace AcadmyCourses.IDentity.Application.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<Result<PermissionAddToGroups>> AssignPermissionToGroupAsync(Guid groupId, List<Guid> permissionCodes, CancellationToken ct)
        {
            return await _userGroupRepository.AssidnPermissionToGroupAsync(groupId, permissionCodes, ct);
        }

        public async Task<Result<CreateUserGroupDtos>> CreateUserGroupasync(DataUserGroupDtos data, CancellationToken ct)
        {
            return await _userGroupRepository.CreateUserasync(data, ct);
        }

        public async Task<Result<List<dynamic>>> GetAllUserGroupAsync(CancellationToken ct)
        {
            return await _userGroupRepository.GetAllUserGroupAsync(ct);
        }

        public async Task<Result<UserGroupAndUser>> GetUserGroupById(Guid id, CancellationToken ct)
        {
            return await _userGroupRepository.GetUserGroupById(id , ct);
        }

        public async Task<Result<CreateUserGroupDtos>> UpdateUserGroupasync(Guid id, DataUserGroupDtos data, CancellationToken ct)
        {
            return await _userGroupRepository.UpdateUserasync(id, data, ct);
        }
    }
}
