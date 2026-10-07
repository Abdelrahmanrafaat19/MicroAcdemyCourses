using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcadmyCourses.IDentity.Application.Contracts.Servicees
{
    public interface IUserGroupService
    {
        Task<Result<CreateUserGroupDtos>> CreateUserGroupasync(DataUserGroupDtos data, CancellationToken ct);
        Task<Result<CreateUserGroupDtos>> UpdateUserGroupasync(Guid id, DataUserGroupDtos data, CancellationToken ct);
    }
}
