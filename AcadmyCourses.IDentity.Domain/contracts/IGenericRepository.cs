using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Domain.contracts
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync<IDType>(IDType id);

        Task<T?> GetAsync(ISpecification<T> specification);
        Task AddRangeAsync(IEnumerable<T> entities);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllAsync(
            ISpecification<T> specification);

        Task<int> CountAsync(
            ISpecification<T> specification);

        Task<bool> AnyAsync(
            ISpecification<T> specification);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
