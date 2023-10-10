using EmployeePortal.Areas.Identity.Data.Employee;

namespace EmployeePortal.Interface
{
    public interface IUnitOfWork
    {
        IRepository<EmployeeEntity> EmployeeRepo { get; }
        Task<int> SaveAsync();
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
