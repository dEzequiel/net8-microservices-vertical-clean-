using Catalog.Api.Domain.Enums;
using Catalog.Api.DTOs;
using Catalog.Api.Features.FindProductsByCategory;

namespace UnitTest.Catalog.Handlers
{
    public class FindAllProductsByCategoryQueryHandler_Test
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public FindAllProductsByCategoryQueryHandler_Test() =>
            _productRepositoryMock = new();
        

        [Fact]
        public async Task FindProductByCategoryIds_ReturnsExpected()
        {
            // Arrange
            IEnumerable<int> productCategoriesIds = new List<int>() { 1, 6, 3 };
            List<Product> products = new()
        {
            new Product(
                Guid.NewGuid(),
                "Fitbit Charge 5",
                "The Fitbit Charge 5 is an advanced fitness tracker with built-in GPS, heart rate monitoring, and sleep tracking.",
                999.99m,
                (int)ProductCategories.InteligentDevices
            ),
            new Product(
                Guid.NewGuid(),
                "Nintendo Switch",
                "The Nintendo Switch is a versatile gaming console that can be played in handheld mode or connected to a TV for home gaming.",
                999.99m,
                (int)ProductCategories.Electronics
            ),
            new Product(
                new Guid("11111111-1111-1111-1111-111111111111"),
                "iPhone 13 Pro",
                "The iPhone 13 Pro is the latest flagship smartphone from Apple.",
                999.99m,
                (int)ProductCategories.MobilePhone
            ),
            new Product(
                new Guid("22222222-2222-2222-2222-222222222222"),
                "Samsung Galaxy Watch 4",
                "The Samsung Galaxy Watch 4 is a stylish and feature-packed smartwatch.",
                999.99m,
                (int)ProductCategories.InteligentDevices
            ),
            new Product(
                new Guid("44444444-4444-4444-4444-444444444444"),
                "Sony WH-1000XM4",
                "The Sony WH-1000XM4 is a top-of-the-line wireless noise-canceling headphone with excellent sound quality and comfort.",
                999.99m,
                (int)ProductCategories.Computer
            )
        };
            var results = products.Where(x => productCategoriesIds.Contains(x.ProductCategoryId));

            var query = new FindAllProductsByCategoryQuery(productCategoriesIds);

            _productRepositoryMock.Setup(
                x => x.GetProductsByCategory(
                    productCategoriesIds, It.IsAny<CancellationToken>()))
                .ReturnsAsync(results);

            var handler = new FindProductsByCategoryQueryHandler(_productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, default);

            // Assert
            _productRepositoryMock.Verify(m => m.GetProductsByCategory(productCategoriesIds ,default), Times.Once());
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.Contains(result.Products, prod => prod is ProductDTO);
            
            var dtoIds = result.Products.Select(x => x.id);
            var productIds = results.Select(x => x.Id);
            Assert.Equal(productIds, dtoIds);

        }
    }


}
