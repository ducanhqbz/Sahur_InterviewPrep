using AutoMapper;
using InterviewPrep.API.Application.DTOs.MockSession;
using InterviewPrep.API.Data.Repositories;

namespace InterviewPrep.API.Application.Services
{
    public class SessionAnswerService : ISessionAnswerService
    {
        private readonly ISessionAnswerRepository _repository;
        private readonly IMapper _mapper;

        public SessionAnswerService(ISessionAnswerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SessionAnswerDTO>> GetAnswersBySessionIdAsync(long sessionId)
        {
            var entities = await _repository.getSessionAnswerwithUserID(sessionId);
            return _mapper.Map<List<SessionAnswerDTO>>(entities);
        }
    }
}
