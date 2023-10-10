using EmployeePortal.Areas.Identity.Data.Employee;

namespace EmployeePortal.Service
{
    public interface IEmployeeService
    {
        Task<bool> Create(EmployeeEntity request);
        Task<IEnumerable<EmployeeEntity>> GetAll();
        Task<EmployeeEntity?> GetById(string id);
        Task<bool> Update(EmployeeEntity request);
        Task<bool> Delete(string id);
    }
}
