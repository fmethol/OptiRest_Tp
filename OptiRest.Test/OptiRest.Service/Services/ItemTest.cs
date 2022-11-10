using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using OptiRest.Data.Context;
using OptiRest.Service.Services;

namespace OptiRest.Test.OptiRest.Service.Services
{
    public class ItemTest
    {
        private ItemService _itemService;
        
        [SetUp]
        public void Setup()
        {
            var appDbContext = GetDatabaseContext();
            _itemService = new ItemService(appDbContext);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private AppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new AppDbContext(options);
            
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}