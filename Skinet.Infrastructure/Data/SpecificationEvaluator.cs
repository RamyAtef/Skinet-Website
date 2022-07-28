using Microsoft.EntityFrameworkCore;
using Skinet.Core.Entities;
using Skinet.Core.Spacification;

namespace Skinet.Infrastructure.Data;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inpQuery, ISpecification<TEntity> spec)
    {
        var query = inpQuery;

        if (spec.Criteria is not null)
            query = query.Where(spec.Criteria);

        query = spec.Includes.Aggregate(query,
            (current, include) => current.Include(include));

        return query;
    }
}