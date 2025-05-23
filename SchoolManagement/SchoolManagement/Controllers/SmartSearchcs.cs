using AutoMapper;
using ClickWise.Core.Entities;
using ClickWise.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmartSearchController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IStudentService _studentService;


        public SmartSearchController(IHttpClientFactory clientFactory, IStudentService studentService)
        {
            _clientFactory = clientFactory;
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AiSearchRequest request)
        {
            var students = await _studentService.GetAllAiDtoAsync();

            var body = new
            {
                query = request.Query,
                students = students
            };

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync("https://cllickwise-python.onrender.com/ask", body);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
            return Ok(result);
        }

    }

}

