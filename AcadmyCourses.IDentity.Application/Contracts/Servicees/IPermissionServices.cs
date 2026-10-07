using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using StockManagment.Application.common;

namespace AcadmyCourses.IDentity.Application.Contracts.Servicees
{
    public interface IPermissionServices
    {
        Task<Result<bool>> CreatePermissionAsync(CreatePermissionDto data, CancellationToken ct);
        Task<Result<IReadOnlyList<PermissionDto>>> GetAllPermissionAsync(CancellationToken cancellationToken);

        Task<Result<PermissionDto>> GetPermissionByCode(string Code, CancellationToken cancellationToken);
    }
}
