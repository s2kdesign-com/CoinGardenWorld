using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        internal readonly MobileAppDbContext context;
        internal readonly DbSet<TEntity> dbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GenericRepository(MobileAppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            _httpContextAccessor = httpContextAccessor;
        }

        //public virtual IEnumerable<TEntity>? Get(
        //    Expression<Func<TEntity, bool>>? filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public virtual IQueryable<TEntity> List(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "",
            bool includeDeleted = false)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!includeDeleted)
            {
                query = query.Where(e => e.DeletedAt == null);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        //public virtual TEntity? GetById(object id)
        //{
        //    return dbSet.Find(id);
        //}


        public virtual async Task<bool> ExistAsync(Guid id)
        {
            return await dbSet.AnyAsync(entity => entity.Id == id);
        }


        public virtual async Task<TEntity?> GetByIdAsync(Guid id,
        string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = dbSet;

            query = query.Where(e => e.Id == id);

            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
           // entity.CreatedFrom = GetUserId();

            dbSet.Add(entity);
            return entity;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            entityToUpdate.UpdatedOn = DateTime.UtcNow;
            //entityToUpdate.UpdatedFrom = GetUserId();

            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //public virtual void Delete(object id)
        //{
        //    TEntity entityToDelete = dbSet.Find(id);
        //    Delete(entityToDelete);
        //}

        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
           // entityToDelete.DeletedFrom = GetUserId();
            entityToDelete.DeletedAt = DateTime.UtcNow;

            dbSet.Attach(entityToDelete);
            context.Entry(entityToDelete).State = EntityState.Modified;

          //  Delete(entityToDelete);
        }

        private Guid GetUserId()
        {
            var result = Guid.NewGuid();
            if (_httpContextAccessor.HttpContext is { User.Identity.IsAuthenticated: true })
            {
                var value = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (value == null)
                    throw new Exception($"User Id can not be found to edit new: {nameof(TEntity)}, System Administrators are informed.");

                if(Guid.TryParse(value, out var guid))
                    result = guid;
                else
                    throw new Exception($"User Id can not be parsed to edit new: {nameof(TEntity)}, System Administrators are informed.");
            }
            else
            {
                throw new Exception($"User is not authorized to edit new: {nameof(TEntity)}, System Administrators are informed.");
            }

            return result;
        }

        private void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        
    }
}
