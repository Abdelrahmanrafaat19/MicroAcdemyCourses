using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Application.Contracts.Repositories
{
    public interface IPermissionRepository
    {
        Task<Result<bool>> CreatePermissionAsync(CreatePermissionDto permissionData , CancellationToken cancellationToken);
        Task<Result<IReadOnlyList<PermissionDto>>> GetAllPermissionAsync(CancellationToken cancellationToken);
        Task<Result<PermissionDto>> GetPermissionByCode(string Code, CancellationToken cancellationToken);
    }
}
