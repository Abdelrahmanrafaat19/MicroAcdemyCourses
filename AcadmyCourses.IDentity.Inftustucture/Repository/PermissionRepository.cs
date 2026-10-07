using AcadmyCourses.IDentity.Application.Contracts.Repositories;
using AcadmyCourses.IDentity.Application.Dtos.PermissionDto;
using AcadmyCourses.IDentity.Domain.contracts;
using AcadmyCourses.IDentity.Inftustucture.Entities;
using AcadmyCourses.IDentity.Inftustucture.Specification;
using AutoMapper;
using StockManagment.Application.common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcadmyCourses.IDentity.Inftustucture.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public PermissionRepository(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<Result<bool>> CreatePermissionAsync(CreatePermissionDto permissionData, CancellationToken cancellationToken)
        {
            var permissionSpecification = new PermissionSepcefication(permissionData.Code);
            var permissionExist = await _uniteOfWork.GetRepository<Permission>().AnyAsync(permissionSpecification);

            if (permissionExist)
            {
                return Result<bool>.Failure(Error.Validation("ErrorType.Validation", "Permission already exists"));
            }

            var permission = _mapper.Map<Permission>(permissionData);
            permission.Id = Guid.NewGuid();

            await _uniteOfWork.GetRepository<Permission>().AddAsync(permission);
            await _uniteOfWork.SaveChangesAsync(cancellationToken);

            return Result<bool>.Success(true);
        }

        public async Task<Result<IReadOnlyList<PermissionDto>>> GetAllPermissionAsync(CancellationToken cancellationToken)
        {
            var getPermissions = await _uniteOfWork.GetRepository<Permission>().GetAllAsync();
            var permissionData = _mapper.Map<IReadOnlyList<PermissionDto>>(getPermissions);
            return Result<IReadOnlyList<PermissionDto>>.Success(permissionData);

        }

        public async Task<Result<PermissionDto>> GetPermissionByCode(string Code, CancellationToken cancellationToken)
        {
            var permissionSpecification = new PermissionSepcefication(Code);
            var permissionExist = await _uniteOfWork.GetRepository<Permission>().GetAsync(permissionSpecification);
            if (permissionExist == null)
            {
                return Result<PermissionDto>.Failure(Error.Validation("ErrorType.Validation", "Permission not found"));
            }
            return Result<PermissionDto>.Success(_mapper.Map<PermissionDto>(permissionExist));
        }
    }
}
