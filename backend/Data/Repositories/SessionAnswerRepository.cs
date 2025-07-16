using InterviewPrep.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrep.API.Data.Repositories
{
    public class SessionAnswerRepository : ISessionAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SessionAnswer>> getSessionAnswerwithUserID( long sessionId)
        {
            return await _context.SessionAnswers.Where(x=>x.SessionId.Equals(sessionId)).ToListAsync();
        }
    }
}
