﻿namespace Catalog.API.Products.CreatProduct
{
    public record createProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint
    {

    }
}
