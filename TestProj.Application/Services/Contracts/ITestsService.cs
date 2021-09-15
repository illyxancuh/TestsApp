using System.Collections.Generic;
using System.Threading.Tasks;
using TestProj.Application.DTOs;

namespace TestProj.Application.Services.Contracts
{
    public interface ITestsService
    {
        public Task<IReadOnlyCollection<TestSummaryDTO>> GetUserTestsSummary(string userId);
        public Task<TestSummaryDTO> GetUserTestSummary(string userId, string testId);
    }
}
