using AutoMapper;
using EmployeePortal.Areas.Identity.Data.Employee;
using EmployeePortal.Interface;
using EmployeePortal.Models;
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
        public IActionResult Create(InsertEmployeeRequest employee)
        {
            return View(employee);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(InsertEmployeeRequest model)
        {
            var _entity = _mapper.Map<EmployeeEntity>(model);
            var createEmp = await _business.Create(_entity);
            if (createEmp)
            {
                TempData["SuccessMessage"] = "Employee created successfully.";
                return RedirectToAction("Create");
            }
            
            TempData["ErrorMessage"] = "Employee creation failed.";
            return View("Create", model);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] PaginationFilter filter)
        {
            var response = await _business.GetAll(filter);

            // Return the data in the format expected by DataTables
            return Json(new
            {
                draw = filter.draw,
                recordsTotal = response.TotalCount,
                recordsFiltered = response.TotalCount, // Use the total count as recordsFiltered
                data = response.Data.Select(e => _mapper.Map<ViewEmployeeModel>(e))
            });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var _entity = _mapper.Map<InsertEmployeeRequest>(await _business.GetById(id));
            return RedirectToAction("Create", _entity);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(InsertEmployeeRequest model)
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
