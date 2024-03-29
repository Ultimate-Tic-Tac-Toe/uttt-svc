using MongoDB.Driver;
using Moq;
using UtttApi.DataContext.Interfaces;
using UtttApi.DataContext.Services;
using UtttApi.DataContext.Settings;
using Xunit;

namespace UtttApi.UnitTesting.Tests
{
    public class UnitOfWorkTests
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkTests()
        {
            var settings = new MongoDbSettings()
            {
                MongoUri = "mongodb://test123",
                UtttCollection = "TestCollection",
                UtttDb = "Test",
            };

            var mockDb = new Mock<IMongoDatabase>();
            var mockClient = new Mock<IMongoClient>();
            mockClient.Setup(c => c.GetDatabase(
                settings.UtttDb,
                It.IsAny<MongoDatabaseSettings>()
            )).Returns(mockDb.Object);

            unitOfWork = new UnitOfWork(mockClient.Object, settings);
        }

        [Fact]
        public void UnitOfWork_ShouldBeCreated()
        {
            Assert.NotNull(unitOfWork);
            Assert.NotNull(unitOfWork.Game);
        }
    }
}