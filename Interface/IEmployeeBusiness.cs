using EmployeePortal.Areas.Identity.Data.Employee;

namespace EmployeePortal.Interface
{
    public interface IEmployeeBusiness
    {
        Task<bool> Create(EmployeeEntity employee);
        Task<IEnumerable<EmployeeEntity>> GetAll();
        Task<EmployeeEntity> GetById(string id);
        Task<bool> Update(EmployeeEntity employee);
        Task<bool> Delete(string id);
    }
}
