using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Services;
using ClickWise.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentBasicInfoDTO>>> Get()
        {
            var users = await _studentService.GetAllAsync();
            if (users == null || !users.Any())
            {
                return NoContent(); // 204
            }
            return Ok(users);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            StudentBasicInfoDTO s = await _studentService.GetByIdAsync(id);
            if (s == null) return NotFound(id);

            return Ok(s);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] StudentBasicInfoDTO student)
        {
            if (student == null)
            {
                return
                    BadRequest("Invalid student data.");
            }
            var createdUser = await _studentService.Add(student);

            if (createdUser == null) return BadRequest("Failed to create student.");


            return Ok(createdUser);
            
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentBasicInfoDTO student)
        {
            if (student == null) return BadRequest();
            var updatedUser = await _studentService.UpdateAsync(id, student);
            if (updatedUser == null) return NotFound();

            return Ok(updatedUser);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await _studentService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
