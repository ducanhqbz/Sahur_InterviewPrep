using System.Security.Claims;
using InterviewPrep.API.Application.DTOs.MockSession;
using InterviewPrep.API.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrep.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class SessionAnswerController : ControllerBase
    {
        private readonly ISessionAnswerService _service;

        public SessionAnswerController(ISessionAnswerService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("by-session/{sessionId:long}")]
        public async Task<ActionResult<List<SessionAnswerDTO>>> GetAnswersBySessionId(long sessionId)
        {
            var answers = await _service.GetAnswersBySessionIdAsync(sessionId);
            return Ok(answers);
        }

        [Authorize]
        [HttpGet("getUser")]
        public IActionResult GetUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);

            if (userId == null || role == null)
            {
                return Unauthorized(new { message = "User ID or Role not found." });
            }

            return Ok(new
            {
                userId,
                role
            });
        }
    }
}
