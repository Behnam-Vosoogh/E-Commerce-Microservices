namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);


    internal class DeleteProductCommandHandler(IDocumentSession session,ILogger<DeleteProductCommandHandler>logger):ICommandHandler<DeleteProductRequest, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductRequest command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
