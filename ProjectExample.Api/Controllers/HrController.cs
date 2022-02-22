using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectExample.Domain;
using ProjectExample.Interface.Services;

namespace ProjectExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {
        private readonly IHrService _service;

        public HrController(IHrService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(HrDomain hrUser)
        {
            try
            {
                await _service.Add(hrUser);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }


        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<HrDomain>> Get(int id)
        {
            try
            {
                var hrUser = await _service.Get(id);
                return StatusCode(200, hrUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<HrDomain>>> GetAll()
        {
            try
            {
                var hrUsers = await _service.GetAll();
                return StatusCode(200, hrUsers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(418);
            }
        }

        [HttpDelete]
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
