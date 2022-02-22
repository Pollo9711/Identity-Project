using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using ProjectExample.Domain;
using ProjectExample.Interface.Services;


namespace ProjectExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(EmployeeDomain employ)
        {
            try
            {
                await _service.Add(employ);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<EmployeeDomain>> Get(int id)
        {
            try
            {
                var employ = await _service.Get(id);
                return StatusCode(200, employ);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDomain>>> GetAll()
        {
            try
            {
                var employee = await _service.GetAll();
                return StatusCode(200, employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }


        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }
        }




    }
}
