using FluentValidationNET5.Models;
using FluentValidationNET5.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationNET5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IRepository<Student> repository)
        {
            return Ok(repository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(  [FromBody] Student student, 
                                    [FromServices] IRepository<Student> repository)
        {
            return Ok(repository.Create(student));
        }
    }
}