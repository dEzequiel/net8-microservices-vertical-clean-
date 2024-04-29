namespace UnitTest.Catalog.Handlers
{
    public class FindProductByIdQueryHandler_Test
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<DatabaseContext> _databaseContextMock;

        public FindProductByIdQueryHandler_Test()
        {
            _productRepositoryMock = new();
            _databaseContextMock = new Mock<DatabaseContext>(new DbContextOptions<DatabaseContext>());
        }

        [Fact]
        public async Task FindProductByIdQueryHandler_ThrowsNotFoundException_Test()
        {
            // Arrange
            var id = Guid.NewGuid();
            var query = new FindProductByIdQuery(id);

            Product prod = null;
            _productRepositoryMock.Setup(
                x => x.GetProductById(
                    It.IsAny<Guid>()))
                .Returns(prod);

            var handler = new FindProductByIdQueryHandler(
                _productRepositoryMock.Object);

            // Act & assert
            await Assert.ThrowsAnyAsync<NullReferenceException>(async ()
                => await handler.Handle(query, default));

            _productRepositoryMock.Verify(m => m.GetProductById(id), Times.Once());
        }

        [Theory]
        [AutoMoqData]
        public async Task FindProductByIdQueryHandler_ReturnsResponse_Test(
            [Frozen] Product productResponse)
        {
            // Arrange
            var id = Guid.NewGuid();
            var query = new FindProductByIdQuery(id);

            _productRepositoryMock.Setup(
                x => x.GetProductById(id))
                .Returns(productResponse);

            var handler = new FindProductByIdQueryHandler(
                _productRepositoryMock.Object);

            // Act 
            var result = await handler.Handle(query, default);
            Product prod = result.Product;

            // Assert
            _productRepositoryMock.Verify(m => m.GetProductById(id), Times.Once());
            Assert.NotNull(prod);
            Assert.IsType<Product>(prod);
        }
    }
}
