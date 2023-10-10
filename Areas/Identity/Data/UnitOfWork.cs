using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace EmployeePortal.Areas.Identity.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly ApplicationDbContext _context;
        IDbContextTransaction dbContextTransaction;
        private IRepository<EmployeeEntity> _employeeRepo;
        #endregion

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Repositories
        public IRepository<EmployeeEntity> EmployeeRepo
        {
            get
            {
                if (this._employeeRepo == null)
                    this._employeeRepo = new EfRepository<EmployeeEntity>(_context);

                return _employeeRepo;
            }
        }
        #endregion

        public void BeginTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbContextTransaction == null)
            {
                dbContextTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (dbContextTransaction == null)
            {
                dbContextTransaction.Rollback();
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
