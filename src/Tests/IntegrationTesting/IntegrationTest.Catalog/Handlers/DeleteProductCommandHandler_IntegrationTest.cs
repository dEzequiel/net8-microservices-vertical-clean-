using Catalog.Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Catalog.Handlers
{
    public class DeleteProductCommandHandler_IntegrationTest : BaseIntegrationTest
    {
        public DeleteProductCommandHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Theory]
        [AutoMoqData]
        public async Task DeleteProductDCommandHandler_ShouldDeleteProduct_ReturnsResponse_IntegrationTest(
            Product productToAdd)
        {
            // Arrange
            Product prod = new Product(
                Guid.NewGuid(),
                Guid.NewGuid(),
                productToAdd.Name, 
                productToAdd.Description, 
                productToAdd.ProductCategoryId,
                (int)ProductCategories.Computer);

            _dbContext.Products.Add(prod);
            _dbContext.SaveChanges(); 
            _dbContext.Entry(prod).State = EntityState.Detached;

            var command = new DeleteProductCommand(prod.Id);

            // Act
            var result = await _sender.Send(command);

            // Assert
            Assert.True(result.IsSuccess);
            var prodEntity = _dbContext.Products.Find(prod.Id);
            Assert.Null(prodEntity);
        }
    }
}
