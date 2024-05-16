using Catalog.Api.Domain.Enums;

namespace IntegrationTest.Catalog.Handlers
{
    public class AddProductCommandHandler_IntegrationTest : BaseIntegrationTest
    {
        public AddProductCommandHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Theory]
        [AutoMoqData]
        public async Task AddProductCommandHandler_ShouldAddProduct_ReturnsResponse_IntegrationTest(
            [Frozen] Product prodToAdd)
        {
            // Arrange
            var command = new AddProductCommand(prodToAdd.Name, prodToAdd.Description, prodToAdd.Price, 
                (ProductCategories)prodToAdd.ProductCategoryId);

            // Act
            var result = await _sender.Send(command);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AddProductCommandResponse>(result);
            Assert.IsType<Guid>(result.Id);
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == result.Id);
            Assert.NotNull(product);
        }
    }
}
