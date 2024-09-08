using Awc.Dapr.Services.Company.API.ViewModels;
using Awc.Dapr.Services.Company.API.Services;

namespace Company.API.IntegrationTests.Services
{
    [Collection("Database Test")]
    public class CompanyServiceTests : TestBase
    {
        private readonly CompanyService _companyService;

        public CompanyServiceTests()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<CompanyService>();            
            _companyService = new CompanyService(_dapperCtx, logger);
        } 

        [Fact]
        public async Task GetCompanyViewModel_CompanyService_ValidCompanyId_ShouldSucceed()
        {
            // Arrange
            const int companyId = 1;

            // Act
            Result<CompanyViewModel> result = await _companyService.GetCompanyViewModel(companyId);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Value.Departments);
            Assert.NotEmpty(result.Value.Shifts);
        } 

        [Fact]
        public async Task GetCompanyViewModel_CompanyService_InvalidCompanyId_ShouldFail()
        {
            // Arrange
            const int companyId = -1;

            // Act
            Result<CompanyViewModel> result = await _companyService.GetCompanyViewModel(companyId);

            // Assert
            Assert.True(result.IsFailure);
        }                 
    }
}