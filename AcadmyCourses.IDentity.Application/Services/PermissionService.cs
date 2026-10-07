using AcadmyCourses.IDentity.Application.Contracts.Repositories;
using AcadmyCourses.IDentity.Application.Contracts.Servicees;
using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Services
{
    public class PermissionService : IPermissionServices
    {
        private readonly IPermissionRepository _permissionRepo;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepo = permissionRepository;
        }
        public async Task<Result<bool>> CreatePermissionAsync(CreatePermissionDto data, CancellationToken ct)
        {
            return await _permissionRepo.CreatePermissionAsync(data, ct);
        }

        public async Task<Result<IReadOnlyList<PermissionDto>>> GetAllPermissionAsync(CancellationToken cancellationToken)
        {
            return await _permissionRepo.GetAllPermissionAsync(cancellationToken);
        }

        public async Task<Result<PermissionDto>> GetPermissionByCode(string Code, CancellationToken cancellationToken)
        {
            return await _permissionRepo.GetPermissionByCode(Code, cancellationToken);
        }
    }
}
