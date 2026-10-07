

using AcadmyCourses.IDentity.Domain.contracts;
using AcadmyCourses.IDentity.Inftustucture.IDentityContext;
using Microsoft.EntityFrameworkCore;

namespace AcadmyCourses.IDentity.Inftustucture.Repository
{

    public class GenericRepo<T> : IGenericRepository<T> where T : class
    {
        private readonly IDentityDbContext _context;

        public GenericRepo(IDentityDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync<IDType>(IDType id)
        {
            return await _context
                .Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> GetAsync(
            ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(
            ISpecification<T> specification)
        {
            return await ApplySpecification(specification)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> CountAsync(
            ISpecification<T> specification)
        {
            return await ApplySpecification(specification)
                .CountAsync();
        }

        public async Task<bool> AnyAsync(
            ISpecification<T> specification)
        {
            return await ApplySpecification(specification)
                .AnyAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        private IQueryable<T> ApplySpecification(
            ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(
                _context.Set<T>(),
                specification);
        }
    }
}
