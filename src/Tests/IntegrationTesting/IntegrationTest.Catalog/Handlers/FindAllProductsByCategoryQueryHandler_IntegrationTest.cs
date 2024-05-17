using Catalog.Api.Domain.Enums;
using Catalog.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Catalog.Handlers
{
    public class FindAllProductsByCategoryQueryHandler_IntegrationTest : BaseIntegrationTest
    {
        public FindAllProductsByCategoryQueryHandler_IntegrationTest(IntegrationTestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task FindAllProductsByCategoryQueryHandler_ShouldReturnResponse_IntegrationTest()
        {
            // Arrange
            IEnumerable<int> productCategoriesIds = new List<int>() { 1, 6, 3 };
            var query = new FindAllProductsByCategoryQuery(productCategoriesIds);

            // Act
            var result = await _sender.Send(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Products);
            Assert.All(result.Products, prod => Assert.IsType<ProductDTO>(prod));

            // Extracting category ids from the result
            var resultCategoryIds = result.Products
                .Select(x => Enum.TryParse(x.category, out ProductCategories category) ? (int)category : (int)ProductCategories.MobilePhone)
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            // Asserting that the category ids in the result match the provided category ids
            Assert.Equal(productCategoriesIds.OrderBy(x => x), resultCategoryIds);

        }
    }
}
