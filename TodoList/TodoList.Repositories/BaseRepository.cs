using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TodoList.Repositories;

public class BaseRepository<C, E> where C : DbContext where E : class
{
    #region Constructor

    public BaseRepository(C context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #endregion

    #region Properties

    public virtual C Context
    {
        get;
        private set;
    }

    #endregion

    #region Methods Add

    public virtual EntityEntry<E> Add(E entity)
    {
        return Context.Add(entity);
    }

    public virtual async ValueTask<EntityEntry<E>> AddAsync(E entity)
    {
        return await Context.AddAsync(entity);
    }

    #endregion

    #region Methods AddRange

    public virtual void AddRange(IEnumerable<E> entities)
    {
        Context.AddRange(entities);
    }

    public virtual async Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
    {
        await Context.AddRangeAsync(entities, cancellationToken);
    }

    #endregion

    #region Methods Find

    public virtual E? Find(params object[] keyValues)
    {
        return Context.Find<E>(keyValues);
    }

    public virtual async ValueTask<E?> FindAsync(params object[] keyValues)
    {
        return await Context.FindAsync<E>(keyValues);
    }

    public virtual async ValueTask<E?> FindAsync(object[] keyValues, CancellationToken cancellationToken)
    {
        return await Context.FindAsync<E>(keyValues, cancellationToken);
    }

    #endregion

    #region Methods Remove

    public virtual EntityEntry<E> Remove(E entity)
    {
        return Context.Remove(entity);
    }

    public virtual void RemoveRange(params E[] entities)
    {
        Context.RemoveRange(entities);
    }

    public virtual void RemoveRange(IEnumerable<E> entities)
    {
        Context.RemoveRange(entities);
    }

    #endregion

    #region Methods Set

    public virtual DbSet<E> Set()
    {
        return Context.Set<E>();
    }

    #endregion

    #region Methods Save

    public virtual int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Methods Helpers

    public virtual object[] GetEntityKey(E entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (Context == null) throw new InvalidOperationException("Context property is null");

        var properties = Context.Model.FindEntityType(typeof(E))?.FindPrimaryKey()?.Properties;
        var result = new object[properties?.Count ?? 0];

        if (properties != null)
        {
            for (var i = 0; i < properties.Count; i++)
            {
                var p = properties[i];
                result[i] = entity.GetType().GetProperty(p.Name)!.GetValue(entity, null)!;
            }
        }

        return result;
    }

    #endregion
}