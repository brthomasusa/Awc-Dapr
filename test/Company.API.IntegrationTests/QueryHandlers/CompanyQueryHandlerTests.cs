using Awc.Dapr.Services.Company.API.Application.Features.GetCompanyById;
using Awc.Dapr.Services.Company.API.ViewModels;
using Awc.Dapr.Services.Company.API.Services;

namespace Company.API.IntegrationTests.QueryHandlers
{
    [Collection("Database Test")]
    public class CompanyQueryHandlerTests : TestBase
    {
        [Fact]
        public async Task Handle_GetCompanyByIdQueryHandler_ValidCompanyId_ShouldSucceed()
        {
            // Arrange
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<CompanyService>();

            CompanyService service = new(_dapperCtx, logger);            
            GetCompanyByIdQueryHandler handler = new(service, loggerFactory.CreateLogger<GetCompanyByIdQueryHandler>());
            GetCompanyByIdQuery request = new(CompanyId: 1);

            // Act
            Result<CompanyViewModel> response = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(response.IsSuccess);            
        }

        [Fact]
        public async Task Handle_GetCompanyByIdQueryHandler_InvalidCompanyId_ShouldFail()
        {
            // Arrange
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<CompanyService>();

            CompanyService service = new(_dapperCtx, logger);            
            GetCompanyByIdQueryHandler handler = new(service, loggerFactory.CreateLogger<GetCompanyByIdQueryHandler>());
            GetCompanyByIdQuery request = new(CompanyId: -1);

            // Act
            Result<CompanyViewModel> response = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(response.IsFailure);            
        }        
    }
}