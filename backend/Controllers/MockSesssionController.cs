using System.Security.Claims;
using InterviewPrep.API.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrep.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class MockSesssionController : ControllerBase
    {
        private readonly IMockSessionService _mockSessionService;

        public MockSesssionController(IMockSessionService mockSessionService)
        {
            _mockSessionService = mockSessionService;
        }

        [HttpGet("practiceHistory")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized(new { message = "Unauthorized" });

            var sessions = await _mockSessionService.GetUserSessionsAsync(userId);
            return Ok(sessions);
        }
   


    }
}
