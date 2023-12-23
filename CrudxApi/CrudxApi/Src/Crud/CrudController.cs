using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudxApi.Src.Crud
{
    [Route("api/[controller]")]
    public class CrudController : Controller
    {
        private readonly ICrudService _crudService;
        public CrudController(ICrudService crudService)
        {
            _crudService = crudService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetList([FromQuery]int projectId)
        {
            var result = _crudService.GetList(projectId);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _crudService.Get(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CrudViewModel crudViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _crudService.Create(crudViewModel);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CrudViewModel crudViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _crudService.Update(id, crudViewModel);
                if (result == null)
                    return NotFound();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _crudService.Delete(id);
            if (result == null)
                return NotFound();
            return Ok();
        }
    }
}

