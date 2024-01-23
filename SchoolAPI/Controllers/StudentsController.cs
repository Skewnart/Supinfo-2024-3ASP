using DalJ4.Model;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Filters;
using SchoolAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExecutedReqFilter]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get(ISchoolAPI schoolApi)
        {
            return Ok(schoolApi.GetStudents());
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(ISchoolAPI schoolApi, int id)
        {
            var student = schoolApi.GetStudentById(id);
            if (student == null) { return NotFound($"L'étudiant d'id {id} n'a pas été trouvé"); }

            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post(ISchoolAPI schoolApi, [FromBody] Student student)
        {
            try
            {
                var id = schoolApi.CreateStudent(student);

                return Created($"/api/Student/{id}", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ISchoolAPI schoolApi, int id, [FromBody] Student student)
        {
            schoolApi.UpdateStudent(id, student);
            return Ok();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(ISchoolAPI schoolApi, int id)
        {
            schoolApi.RemoveStudent(id);
            return Ok();
        }
    }
}
