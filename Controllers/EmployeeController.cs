using AutoMapper;
using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Interface;
using EmployeePortal.Models.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusiness _business;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeBusiness business, IMapper mapper) 
        {
            _business = business;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(InsertEmployeeModel employee)
        {
            return View(employee);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(InsertEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var _entity = _mapper.Map<EmployeeEntity>(model);
                var createEmp = await _business.Create(_entity);
                if (createEmp)
                {
                    TempData["SuccessMessage"] = "Employee created successfully.";
                    return RedirectToAction("Create");
                }
            }
            TempData["ErrorMessage"] = "Employee creation failed.";
            return View(model); 
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewEmployeeModel>>> GetList()
        {

            var listEmp = await _business.GetAll();
            return Ok(listEmp.Select(e => _mapper.Map<ViewEmployeeModel>(e)));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var _entity = _mapper.Map<InsertEmployeeModel>(await _business.GetById(id));
            return RedirectToAction("Create", _entity);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(InsertEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var _entity = _mapper.Map<EmployeeEntity>(model);
                var updateEmp = await _business.Update(_entity);
                if (updateEmp)
                {
                    TempData["SuccessMessage"] = "Employee updated successfully.";
                    return RedirectToAction("Create", model);
                }
            }
            TempData["ErrorMessage"] = "Employee update failed.";
            return RedirectToAction("Create", model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _business.Delete(id);

            return Ok(id);
        }
    }
}
