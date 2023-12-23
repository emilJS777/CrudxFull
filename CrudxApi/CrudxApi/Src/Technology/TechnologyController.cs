using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudxApi.Src.File;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudxApi.Src.Technology
{
    [Route("api/[controller]")]
    public class TechnologyController : Controller
    {
        private readonly ITechnologyService _technologyService;
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var response = _technologyService.Get();
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _technologyService.Get(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TechnologyViewModel technologyViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = _technologyService.Create(technologyViewModel);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TechnologyViewModel technologyViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = _technologyService.Update(id, technologyViewModel);
                if (response == null)
                    return NotFound();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _technologyService.Delete(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}

