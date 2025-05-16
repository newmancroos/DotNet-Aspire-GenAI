namespace Catalog.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/products");

            group.MapGet("/", async (ProductService productService) =>
            {
                var products =  await productService.GetProductsAsync();
                return Results.Ok(products);
            })
                .WithName("GetAllProducts")
                .Produces<List<Product>>(StatusCodes.Status200OK);

            group.MapGet("/{id}", async (int id, ProductService productService) =>
            {
                var product = await productService.GetProductByIdAsync(id);
                return Results.Ok(product);
            })
                .WithName("GetProductById")
                .Produces<Product>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            group.MapPost("/", async (Product product, ProductService productService) =>
            { 
                await productService.CreateProductAsync(product);
                return Results.Created($"/products/{product.Id}", product);
            })
                .WithName("CreateProduct")
                .Produces(StatusCodes.Status201Created);


            group.MapPut("/{id}", async (int id, Product inputProduct, ProductService productService) =>
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product is null)
                {
                    return Results.NotFound();
                }
                await productService.UpdateProductAsync(product, inputProduct);
                return Results.NoContent();
            })
                .WithName("UpdateProduct")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            group.MapDelete("/{id}", async (int id, ProductService productService) =>
            { 
                var deleteProduct = await productService.GetProductByIdAsync(id);
                if (deleteProduct is null)
                {
                    return Results.NotFound();
                }
                await productService.DeleteProductAsync(deleteProduct);
                return Results.NoContent();
            })
                .WithName("DeleteProduct")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/support/{query}", async (string query, ProductAIService service) =>
            {
                var response = await service.SupportAsync(query);
                return Results.Ok(response);
            })
                .WithName("Support")
                .Produces(StatusCodes.Status200OK);
        }
    }
}
