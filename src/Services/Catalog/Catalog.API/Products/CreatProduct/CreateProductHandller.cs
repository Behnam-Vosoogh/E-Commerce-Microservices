﻿using BuikdingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreatProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,string ImageFile,decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandller : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            // TODO 
            //save product to database


            //return creatProductResult

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
