using Mapster;
using MapsterMapper;

namespace Company.API.IntegrationTests
{
    public static class AddMapsterForUnitTests
    {
        public static Mapper GetMapper()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(
                typeof(ServerAssembly).Assembly
            );

            config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            return new Mapper(config);
        }
    }
}