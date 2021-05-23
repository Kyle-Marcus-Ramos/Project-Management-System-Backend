using Microsoft.AspNetCore.Mvc;
using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProject(SaveProjectRequestDTO saveProjectRequestDTO)
        {
            try
            {
                await _projectService.SaveProject(saveProjectRequestDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred on Saving Project " + ex);
            }
        }

        [HttpPost]
        public async Task<IEnumerable<GetProjectByAccountIDResponseDTO>> GetProjectByAccountId(GetProjectByAccountIdRequestDTO getProjectByAccountIdRequestDTO)
        {
            return await _projectService.GetProjectByAccountId(getProjectByAccountIdRequestDTO);
        }
    }
}
