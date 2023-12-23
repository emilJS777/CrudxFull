using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudxApi.Src.CrudStatic
{
    [Route("api/[controller]")]
    public class CrudStaticController : Controller
    {
        private readonly ICrudStaticService _crudStaticService;
        public CrudStaticController(ICrudStaticService crudStaticService)
        {
            _crudStaticService = crudStaticService;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetList([FromQuery]int technologyId)
        {
            var result = _crudStaticService.GetList(technologyId);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _crudStaticService.Get(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CrudStaticViewModel crudStaticViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _crudStaticService.Create(crudStaticViewModel);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CrudStaticViewModel crudStaticViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _crudStaticService.Update(id, crudStaticViewModel);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _crudStaticService.Delete(id);
            if (result == null)
                return NotFound();
            return Ok();
        }
    }
}

