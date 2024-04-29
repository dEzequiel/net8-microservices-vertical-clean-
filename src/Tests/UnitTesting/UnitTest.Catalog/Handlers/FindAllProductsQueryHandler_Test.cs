namespace UnitTest.Catalog.Handlers
{
    public class FindAllProductsQueryHandler_Test
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<DatabaseContext> _databaseContextMock;

        public FindAllProductsQueryHandler_Test()
        {
            _productRepositoryMock = new();
            _databaseContextMock = new Mock<DatabaseContext>(new DbContextOptions<DatabaseContext>());
        }

        [Fact]
        public async Task FindAllProductsQueryHandler_ReturnsResponse()
        {
            // Arrange
            var query = new FindAllProductsQuery();

            _productRepositoryMock.Setup(
                x => x.GetProducts(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(InitialData.Products);

            var handler = new FindAllProductsQueryHandler(
                _productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            _productRepositoryMock.Verify(m => m.GetProducts(default), Times.Once());
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.Contains(result.Products, prod => prod is Product);
        }

        [Fact]
        public async Task FindAllProductsQueryHandler_ReturnsEmptyResponse_Test()
        {
            // Arrange
            var query = new FindAllProductsQuery();

            _productRepositoryMock.Setup(
                x => x.GetProducts(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Product>());

            var handler = new FindAllProductsQueryHandler(
                _productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            _productRepositoryMock.Verify(m => m.GetProducts(default), Times.Once());
            Assert.NotNull(result);
            Assert.Empty(result.Products);
        }
    }
}