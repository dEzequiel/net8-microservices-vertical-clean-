using Catalog.Api.Data;
using Catalog.Api.Message.Query;
using Crosscutting.CQRS.Infrastructure;

namespace Catalog.Api.Features.FindProductById
{
    public class FindProductByIdQueryHandler : IQueryHandler<FindProductByIdQuery, FindProductByIdQueryResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public FindProductByIdQueryHandler(DatabaseContext databaseContext) =>
            _databaseContext = databaseContext;
        

        public async Task<FindProductByIdQueryResponse> Handle(FindProductByIdQuery query, CancellationToken cancellationToken)
        {
            var id = query.Id;
            var product = await _databaseContext.Products.FindAsync(id);

            if (product is null)
                throw new NullReferenceException();

            var response = new FindProductByIdQueryResponse(product);
            return response;
        }
    }
}
