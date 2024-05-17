using Catalog.Api.DTOs;
using Catalog.Api.Features.FindProductsBetweenPrices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Catalog.Handlers
{
    public class FindAllProductsBetweenPricesQueryHandler_Test
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public FindAllProductsBetweenPricesQueryHandler_Test() =>
            _productRepositoryMock = new();

        [Theory]
        [AutoMoqData]
        public async Task FindAllProductsBetweenPrices_ReturnsExpected(
            [Frozen] IEnumerable<Product> productsMock,
            decimal minPrice,
            decimal maxPrice)
        {
            // Arrange
            var query = new FindAllProductsBetweenPricesQuery(minPrice, maxPrice);

            _productRepositoryMock.Setup(
                x => x.GetProductsBetweenPrices(
                    It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productsMock);

            var handler = new FindProductsBetweenPricesQueryHandler(_productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            _productRepositoryMock.Verify(m => m.GetProductsBetweenPrices(It.IsAny<decimal>(), It.IsAny<decimal>(), default), Times.Once());
            Assert.NotNull(result);
            Assert.NotEmpty(result.products);
            Assert.All(result.products, prod => Assert.IsType<ProductDetailsDTO>(prod));
        }
    }
}
