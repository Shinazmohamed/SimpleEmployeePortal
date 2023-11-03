using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Models;

namespace EmployeePortal.Service
{
    public interface IEmployeeService
    {
        Task<bool> Create(EmployeeEntity request);
        Task<PaginationResponse<EmployeeEntity>> GetAll(PaginationFilter filter);
        Task<EmployeeEntity?> GetById(string id);
        Task<bool> Update(EmployeeEntity request);
        Task<bool> Delete(string id);
    }
}
