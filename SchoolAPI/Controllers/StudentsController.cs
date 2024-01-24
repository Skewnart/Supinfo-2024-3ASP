using DalJ4.Model;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Filters;
using SchoolAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAPI.Controllers
{
    [Route("api/stud/")]
    [ApiController]
    [ExecutedReqFilter]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// L'action pour faire un Get sur l'Entity Framework
        /// </summary>
        /// <param name="schoolApi"></param>
        /// <returns></returns>
        /// <response code="200">Returns all students</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(400)]
        [Route("getall")]
        public IActionResult Get(ISchoolAPI schoolApi)
        {
            return Ok(schoolApi.GetStudents());
        }

        [HttpGet]
        [Route("getby")]
        public IActionResult Get(ISchoolAPI schoolApi, int id)
        {
            var student = schoolApi.GetStudentById(id);
            if (student == null) { return NotFound($"L'étudiant d'id {id} n'a pas été trouvé"); }

            return Ok(student);
        }

        [HttpPost]
        [Route("new")]
        public IActionResult Post(ISchoolAPI schoolApi, [FromBody] Student student)
        {
            try
            {
                var id = schoolApi.CreateStudent(student);

                return Created($"/api/stud/{id}", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Put(ISchoolAPI schoolApi, int id, [FromBody] Student student)
        {
            schoolApi.UpdateStudent(id, student);
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(ISchoolAPI schoolApi, int id)
        {
            schoolApi.RemoveStudent(id);
            return Ok();
        }
    }
}
