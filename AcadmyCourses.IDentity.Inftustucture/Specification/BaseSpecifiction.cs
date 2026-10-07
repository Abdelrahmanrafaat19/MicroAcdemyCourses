using AcadmyCourses.IDentity.Domain.contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AcadmyCourses.IDentity.Inftustucture.Specification
{
    public abstract class BaseSpecification<TEntity>
     : ISpecification<TEntity>
     where TEntity : class
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; }
            = new();

        public Expression<Func<TEntity, object>>? OrderBy { get; protected set; }

        public Expression<Func<TEntity, object>>? OrderByDescending { get; protected set; }


        public int Take { get; protected set; }

        public int Skip { get; protected set; }

        public bool IsPagingEnabled { get; protected set; }

        protected BaseSpecification(
            Expression<Func<TEntity, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        protected void AddInclude(
            Expression<Func<TEntity, object>> include)
        {
            Includes.Add(include);
        }

        protected void AddOrderBy(
            Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        protected void AddOrderByDescending(
            Expression<Func<TEntity, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }
    }
}
