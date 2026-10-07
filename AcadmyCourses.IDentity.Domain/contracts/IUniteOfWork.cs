
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Domain.contracts
{

    public interface IUniteOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity :class;
    }
}
