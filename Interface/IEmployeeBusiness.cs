using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Models;

namespace EmployeePortal.Interface
{
    public interface IEmployeeBusiness
    {
        Task<bool> Create(EmployeeEntity employee);
        Task<PaginationResponse<EmployeeEntity>> GetAll(PaginationFilter filter);
        Task<EmployeeEntity> GetById(string id);
        Task<bool> Update(EmployeeEntity employee);
        Task<bool> Delete(string id);
    }
}
