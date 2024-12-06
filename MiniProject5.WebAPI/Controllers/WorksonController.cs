using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject7.Application.DTOs;
using MiniProject7.Application.Interfaces.IServices;
using MiniProject7.Domain.Models;

namespace MiniProject7.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorksOnController : ControllerBase
    {
        private readonly IWorksOnService _worksOnService;

        public WorksOnController(IWorksOnService worksOnService)
        {
            _worksOnService = worksOnService;
        }

        [Authorize(Roles = "Administrator, HR Manager, Department Manager, Employee Supervisor, Employee")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workson>>> GetAllWorksOn([FromQuery] paginationDto pagination)
        {
            var worksOnList = await _worksOnService.GetAllWorksOnAsync(pagination);
            return Ok(worksOnList);
        }

        [Authorize(Roles = "Administrator, Employee, HR Manager, Employee Supervisor, Employee")]
        [HttpGet("{empId}/{projId}")]
        public async Task<ActionResult<Workson>> GetWorksOn(int empId, int projId)
        {
            var worksOn = await _worksOnService.GetWorksOnByIdAsync(empId, projId);
            if (worksOn == null)
            {
                return NotFound();
            }
            return Ok(worksOn);
        }

        [Authorize(Roles = "Administrator, Employee Supervisor")]
        [HttpPost]
        public async Task<ActionResult<Workson>> AddWorksOn(Workson worksOn)
        {
            var newWorksOn = await _worksOnService.AddWorksOnAsync(worksOn);
            return Ok(newWorksOn);
        }

        [Authorize(Roles = "Administrator, Employee Supervisor")]
        [HttpPut("{empId}/{projId}")]
        public async Task<IActionResult> UpdateWorksOn(int empId, int projId, [FromBody] Workson worksOn)
        {
            await _worksOnService.UpdateWorksOnAsync(empId, projId, worksOn);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Employee Supervisor")]
        [HttpDelete("{empId}/{projId}")]
        public async Task<IActionResult> DeleteWorksOn(int empId, int projId)
        {
            await _worksOnService.DeleteWorksOnAsync(empId, projId);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Employee, Employee Supervisor")]
        [HttpGet("ownWorkson")]
        public async Task<IActionResult> GetOwnWorkson()
        {
            var ownWorkson = await _worksOnService.GetOwnWorksonAsync();
            return Ok(ownWorkson);
        }
    }
}
