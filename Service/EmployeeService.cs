using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Interface;
using EmployeePortal.Models;

namespace EmployeePortal.Service
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public async Task<bool> Create(EmployeeEntity request)
        {
            _unitOfWork.EmployeeRepo.Add(request);
            int result = await _unitOfWork.SaveAsync();
            return result > 0;
        }

        public async Task<PaginationResponse<EmployeeEntity>> GetAll(PaginationFilter filter)
        {
            return await _unitOfWork.EmployeeRepo.GetAll(filter);
        }

        public async Task<EmployeeEntity?> GetById(string id)
        {
            return await _unitOfWork.EmployeeRepo.Get(Guid.Parse(id));
        }

        public async Task<bool> Update(EmployeeEntity request)
        {
            _unitOfWork.EmployeeRepo.Update(request);
            int result = await _unitOfWork.SaveAsync();
            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            await _unitOfWork.EmployeeRepo.Delete(Guid.Parse(id));
            int result = await _unitOfWork.SaveAsync();
            return result > 0;
        }
    }
}
