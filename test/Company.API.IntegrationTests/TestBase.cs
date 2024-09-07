using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.API.IntegrationTests
{
    public abstract class TestBase : IDisposable
    {
        protected readonly CompanyDbContext _dbContext;
        protected readonly DapperContext _dapperCtx;

        protected TestBase()
        {
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__CompanyApi");

            var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();

            optionsBuilder.UseSqlServer(
                connectionString,
                x => x.UseHierarchyId()
            )
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

            _dbContext = new CompanyDbContext(optionsBuilder.Options);
            _dapperCtx = new DapperContext(connectionString!);

            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.usp_InitializeTestDb");
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}