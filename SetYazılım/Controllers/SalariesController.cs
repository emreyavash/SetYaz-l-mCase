using Business.Interface;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SetYazılım.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private ISalaryService _salaryService;

        public SalariesController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _salaryService.GetAll();
            if (result.Count == 0)
            {
                return Ok("Çalışan bulunmamaktadır.");
            }
            return Ok(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _salaryService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("CalculateSalary")]
        public IActionResult CalculateSalary(Salary salary)
        {
            var result = _salaryService.CalculateSalary(salary);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       
        [HttpDelete("Delete")]
        public IActionResult Delete(Salary salary)
        {
            _salaryService.Delete(salary);
            return Ok();
        }
        [HttpPut("Update")]
        public IActionResult Update(Salary salary)
        {
            _salaryService.Update(salary);
            return Ok();
        }
    }
}
