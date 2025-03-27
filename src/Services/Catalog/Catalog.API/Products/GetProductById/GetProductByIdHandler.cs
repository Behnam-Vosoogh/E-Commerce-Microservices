
namespace Catalog.API.Products.GetProductById
{
    public record GetProductByQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler
        (IDocumentSession session,ILogger<GetProductByIdQueryHandler>logger)
        : IQueryHandler<GetProductByQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}",query);
            var product = await session.LoadAsync<Product>(query.Id.ToString(), cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException();

            }
            return new GetProductByIdResult(product);
        }
    }
}
