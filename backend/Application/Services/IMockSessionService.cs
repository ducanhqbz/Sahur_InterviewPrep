using InterviewPrep.API.Application.DTOs.MockSession;

namespace InterviewPrep.API.Application.Services
{
    public interface IMockSessionService
    {
        Task<List<MockSessionDTO>> GetUserSessionsAsync(string userId);
    }
}
