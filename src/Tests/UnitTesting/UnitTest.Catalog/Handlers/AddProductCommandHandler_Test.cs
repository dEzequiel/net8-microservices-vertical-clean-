using Catalog.Api.Domain.Enums;
using Catalog.Api.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UnitTest.Catalog.Handlers
{
    public class AddProductCommandHandler_Test
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUserProvider> _userProviderMock;
        private readonly Mock<DatabaseContext> _databaseContextMock;

        public AddProductCommandHandler_Test()
        {
            _productRepositoryMock = new();
            _userProviderMock = new();
            _databaseContextMock = new Mock<DatabaseContext>(new DbContextOptions<DatabaseContext>());
        }

        [Theory]
        [AutoMoqData]
        public async Task AddProductCommandHandler_ReturnsResponse(
            [Frozen] Product prodToAdd)
        {

            // Arrange
            var command = new AddProductCommand(prodToAdd.Name, prodToAdd.Description, prodToAdd.Price, (ProductCategories)prodToAdd.ProductCategoryId);
            _userProviderMock.Setup(x => x.GetUserId()).Returns(Guid.NewGuid());
            
            _productRepositoryMock.Setup(
                x => x.InsertProduct(It.IsAny<Product>()))
                .Verifiable();

            _productRepositoryMock.Setup(
                x => x.Save())
                .Verifiable();



            var handler = new AddProductCommandHandler(
                _productRepositoryMock.Object,
                _userProviderMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            _productRepositoryMock.Verify(m => m.InsertProduct(It.IsAny<Product>()), Times.Once());
            _productRepositoryMock.Verify(m => m.Save(), Times.Once());
            _userProviderMock.Verify(m => m.GetUserId(), Times.Once());
            Assert.NotNull(result);
            Assert.IsType<AddProductCommandResponse>(result);
            Assert.IsType<Guid>(result.Id);
        }
    }
}
