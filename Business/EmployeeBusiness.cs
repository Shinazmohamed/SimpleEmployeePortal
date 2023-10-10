using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Interface;
using EmployeePortal.Service;

namespace EmployeePortal.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeService _service;
        public EmployeeBusiness(IEmployeeService service) 
        {
            _service = service;
        }
        public async Task<bool> Create(EmployeeEntity employee)
        {
			try
			{
                return await _service.Create(employee);
            }
			catch (Exception)
			{
				throw;
			}
        }
        public async Task<IEnumerable<EmployeeEntity>> GetAll()
        {
            try
            {
                return await _service.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EmployeeEntity> GetById(string id)
        {
            try
            {
                return await _service.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(EmployeeEntity employee)
        {
            try
            {
                return await _service.Update(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                return await _service.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
