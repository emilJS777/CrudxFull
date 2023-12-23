using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudxApi.Src.File
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var response = _fileService.Get();
            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _fileService.Get(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

       // //POST api/values
       //[HttpPost]
       // public bool? Post([FromBody] FileViewModel fileViewModel)
       // {
       //     ApiResponseModel response = _fileService.Create(fileViewModel);
       //     return response;
       // }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FileViewModel fileViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Update(id, fileViewModel);
                if (response == null)
                    return NotFound();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _fileService.Delete(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}

