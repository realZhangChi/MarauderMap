using Shouldly;
using Volo.Abp.Data;
using Xunit;

namespace MarauderMap.Data
{
    public class ConnectionStringResolverTests : MarauderMapDomainTestBase
    {
        private readonly IConnectionStringResolver _connectionStringResolver;

        public ConnectionStringResolverTests()
        {
            _connectionStringResolver = GetRequiredService<IConnectionStringResolver>();
        }

        [Fact]
        public void The_Implementation_of_IConnectionStringResolver_Should_Be_Custom()
        {
            var result = _connectionStringResolver.GetType().Equals(typeof(ConnectionStringResolver));
            result.ShouldBeTrue();
        }

    }
}
