using InterviewPrep.API.Data.Models;

namespace InterviewPrep.API.Data.Repositories
{
    public interface ISessionAnswerRepository
    {
        Task<List<SessionAnswer>> getSessionAnswerwithUserID(long sesssionId);
    }
}
