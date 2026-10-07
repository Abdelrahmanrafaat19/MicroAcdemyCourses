using AcadmyCourses.IDentity.Application.Contracts.Repositories;
using AcadmyCourses.IDentity.Application.Dtos.UserGroupDtos;
using AcadmyCourses.IDentity.Domain.contracts;
using AcadmyCourses.IDentity.Domain.UserGroup;
using AutoMapper;
using StockManagment.Application.common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AcadmyCourses.IDentity.Inftustucture.Repository
{
    public class UerGroupRepository : IUserGroupRepository
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;
        public UerGroupRepository(IUniteOfWork  uniteOfWork , IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<Result<CreateUserGroupDtos>> UpdateUserasync(Guid id, DataUserGroupDtos data, CancellationToken ct)
        {
            var repo = _uniteOfWork.GetRepository<UserGroup>();

            var all = await repo.GetAllAsync();
            var existing = all.FirstOrDefault(g => g.Id == id);

            if (existing is null)
            {
                return Result<CreateUserGroupDtos>.Failure(Error.Failure("NotFound", "User group not found"));
            }

            if (!string.IsNullOrEmpty(data.Name))
            {
                existing.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(data.Description))
            {
                existing.Description = data.Description;
            }
          
            repo.Update(existing);

            var result = await _uniteOfWork.SaveChangesAsync(ct);

            if (result == 0)
            {
                return Result<CreateUserGroupDtos>.Failure(Error.Failure("Failure", "Fail in update user group"));
            }

            var updated = _mapper.Map<CreateUserGroupDtos>(existing);
            return Result<CreateUserGroupDtos>.Success(updated);
        }
        public async Task<Result<CreateUserGroupDtos>> CreateUserasync(DataUserGroupDtos data, CancellationToken ct)
        {
            var newGroup = _mapper.Map<UserGroup>(data);


            await _uniteOfWork.GetRepository<UserGroup>().AddAsync(newGroup);

            var result = await _uniteOfWork.SaveChangesAsync(ct);

            if (result==0)
            {
                return Result<CreateUserGroupDtos>.Failure(Error.Failure("ErrorType.Failure" , "Fail In Create User Group"));
            }

            var createdGroup = _mapper.Map<CreateUserGroupDtos>(newGroup);
            return Result<CreateUserGroupDtos>.Success(createdGroup);
        }
    }
}
