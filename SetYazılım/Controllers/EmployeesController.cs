using Business.Interface;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SetYazılım.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result = _employeeService.GetAll();
            if (result.Count ==0)
            {
                return Ok("Çalışan bulunmamaktadır.");
            }
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Employee employee)
        {
            _employeeService.Add(employee);
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Employee employee)
        {
            _employeeService.Delete(employee);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(Employee employee)
        {
            _employeeService.Update(employee);
            return Ok();
        }
    }
}
