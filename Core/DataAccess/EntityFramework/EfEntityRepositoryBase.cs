


using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TEntityId, TContext> : IEntityRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TContext : DbContext
{

    private readonly TContext Context;

    public EfEntityRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        Context.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.UtcNow;

        if (!isSoftDelete)
            Context.Remove(entity);

        Context.SaveChanges();
        return entity;
    }

    public TEntity? Get(Func<TEntity, bool> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);// Örn. FirstOrDefault metodu veritabanına sorguyu çalıştırır.

    }

    public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
    {
        IQueryable<TEntity> entities = Context.Set<TEntity>();
        if (predicate is not null)
            entities = entities.Where(predicate).AsQueryable();

        return entities.ToList();

        //IQueryable<TEntity> query = Context.AsQueryable();
        //if (predicate != null)
        //{
        //    query = query.Where(predicate).AsQueryable();
        //}


        //return query.ToList(); // metodu veritabanına sorguyu çalıştırır.
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        Context.Update(entity);
        Context.SaveChanges();
        return entity;
    }
}
