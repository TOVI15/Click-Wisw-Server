using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Services;
using ClickWise.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
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
        public async Task<ActionResult> Put(int id, [FromBody] Folders documents)
        {
            if (documents == null) return BadRequest(); ;
            var updatedUser = await _documentService.UploadAsync(id, documents);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);

        }
        [HttpPost]
        public async Task<IActionResult> CreateFolderRecord([FromBody] string S3Key)
        {
            var createFolder = await _documentService.AddAsync(S3Key);
            if (createFolder == null) return NotFound();
            return Ok(createFolder);
        }
        [HttpGet("folder-path")]
        public async Task<IActionResult> GetFolderPath([FromQuery] int studentId)
        {
            var folder = await _documentService.GetByStudentIdAsync(studentId);


            if (folder == null)
                return NotFound();

            return Ok(new { path = folder.S3Key });
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
