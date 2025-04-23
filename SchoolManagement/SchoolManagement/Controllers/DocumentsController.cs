using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Services;
using ClickWise.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentsController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        // GET: api/<DocumentsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var users = await _documentService.GetAllAsync();
            if (users == null || !users.Any())
            {
                return NoContent();
            }
            return Ok(users);
        }

        // GET api/<DocumentsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null) return NotFound(id);
            return Ok(document);
        }


        // PUT api/<DocumentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DocumentsDTO documents)
        {
            if (documents == null) return BadRequest(); ;
            var updatedUser = await _documentService.UploadAsync(id, documents);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);

        }

        // DELETE api/<DocumentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null) return NotFound();

            var isDeleted = await _documentService.DeleteAsync(document);
            if (!isDeleted) return NotFound();

            return NoContent();
        }

    }
}
