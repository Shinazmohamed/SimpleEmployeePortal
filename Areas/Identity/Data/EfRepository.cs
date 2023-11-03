using EmployeePortal.Interface;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeePortal.Areas.Identity.Data
{

    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> _entities;
        #endregion

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Utility
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (Exception)
                    {
                        //ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public virtual void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return await Entities.CountAsync(where);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<int> Count()
        {
            try
            {
                return await Entities.CountAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<bool> Delete(object id)
        {
            try
            {
                var entity = await Entities.FindAsync(id);
                Entities.Remove(entity);
                return true;

            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<bool> Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var entities = Entities.Where(where);
                Entities.RemoveRange(entities);
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<TEntity> Get(object id)
        {
            try
            {
                return await Entities.FindAsync(id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return await Entities.FirstOrDefaultAsync(where);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }
        
        public async Task<PaginationResponse<TEntity>> GetEntitiesWithFilters(PaginationFilter filter)
        {
            try
            {
                var totalCount = Entities.Count();
                var filteredEntities = Entities.Skip(filter.start).Take(filter.length).ToList();

                return new PaginationResponse<TEntity>(
                    filteredEntities,
                    totalCount,
                    filter.draw,
                    filter.length
                );


            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public async Task<PaginationResponse<TEntity>> GetAll(PaginationFilter filter)
        {
            IQueryable<TEntity> query = Entities;

            //// Apply filtering based on the search value
            //if (!string.IsNullOrEmpty(filter.search.value))
            //{
            //    var searchValue = filter.search.value.ToLower(); // Convert to lowercase for case-insensitive search
            //    query = query.Where(e => EntityContainsValue(e, searchValue));
            //}

            //// Apply ordering based on the order properties
            //if (filter.order != null && filter.order.Any())
            //{
            //    var order = filter.order[0]; // Assuming you're handling only one column ordering
            //    int columnIndex = order.column;

            //    // Dynamically get the property name to order by based on columnIndex
            //    var columnProperty = typeof(TEntity).GetProperties()[columnIndex];
            //    string propertyName = columnProperty.Name;

            //    if (order.dir == "asc")
            //    {
            //        query = query.OrderBy(e => columnProperty.GetValue(e));
            //    }
            //    else
            //    {
            //        query = query.OrderByDescending(e => columnProperty.GetValue(e));
            //    }
            //}

            // Perform the count and pagination
            var totalCount = query.Count();
            var filteredEntities = query.Skip(filter.start).Take(filter.length).ToList();

            return new PaginationResponse<TEntity>(
                filteredEntities,
                totalCount,
                filter.draw,
                filter.length
            );
        }

        private bool EntityContainsValue(TEntity entity, string searchValue)
        {
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var propertyValue = property.GetValue(entity);
                if (propertyValue != null && propertyValue.ToString().ToLower().Contains(searchValue))
                {
                    return true;
                }
            }
            return false;
        }



        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return Entities.Where(where);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Update(entity);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        //public void Update(TEntity entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //            throw new ArgumentNullException(nameof(entity));

        //        var entry = _context.Entry(entity);
        //        entry.State = EntityState.Modified;

        //        // Exclude the Id property from being marked as modified
        //        entry.Property("Id").IsModified = false;

        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
        //    }
        //}


        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }

        public virtual void SaveAsync()
        {
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(ex), ex.InnerException);
            }
        }
    }
}
