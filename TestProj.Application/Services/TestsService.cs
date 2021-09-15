using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProj.Application.DTOs;
using TestProj.Application.Exceptions;
using TestProj.Application.Services.Contracts;
using TestProj.DataAccess;
using TestProj.DataAccess.Entities;

namespace TestProj.Application.Services
{
    public class TestsService : ITestsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public TestsService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<TestSummaryDTO>> GetUserTestsSummary(string userName)
        {
            var existingUser = await _databaseContext.GetFirst<User>(user => user.Login == userName);
            if(existingUser == null)
            {
                throw new NotFoundException($"User with id '{userName}' doesn't exists.'");
            }

            return _mapper.Map<ICollection<Test>, IReadOnlyCollection<TestSummaryDTO>>(existingUser.Tests);
        }

        public async Task<TestSummaryDTO> GetUserTestSummary(string userName, string testId)
        {
            var user = await _databaseContext.GetFirst<User>(user => user.Login == userName);
            if(user == null)
            {
                throw new NotFoundException($"User '{userName}' doesn't exists.");
            }

            var test = user.Tests.FirstOrDefault(test => test.Id == testId);
            if(test == null)
            {
                throw new NotFoundException($"User '{userName}' has no test with id '{testId}'.");
            }

            return _mapper.Map<Test, TestSummaryDTO>(test);
        }
    }
}
