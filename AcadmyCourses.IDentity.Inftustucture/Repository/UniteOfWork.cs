using AcadmyCourses.IDentity.Domain.contracts;
using AcadmyCourses.IDentity.Inftustucture.IDentityContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Repository
{
    public class UniteOfWork(IDentityDbContext context) : IUniteOfWork
    {
        private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var typeName = typeof(TEntity).Name;
            Console.WriteLine($"this is Type{typeName} ");

            if (_repositories.TryGetValue(typeName, out object OldRepos))
                return (IGenericRepository<TEntity>)OldRepos;

            var NewRepo = new GenericRepo<TEntity>(context);
            _repositories[typeName] = NewRepo;
            return NewRepo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await context.SaveChangesAsync(ct);
        }
    }
}
