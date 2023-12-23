using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudxApi.Src.Project
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var response = _projectService.Get();
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _projectService.Get(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // DELETE api/values/5
        [HttpPatch]
        public IActionResult Patch([FromQuery]int projectId)
        {
            var response = _projectService.OnLaunch(projectId);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = _projectService.Create(projectViewModel);
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _projectService.Delete(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}

