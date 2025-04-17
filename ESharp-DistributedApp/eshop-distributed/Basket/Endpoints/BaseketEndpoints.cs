namespace Basket.Endpoints;

public static class BaseketEndpoints
{
    public static void MapBasketEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("basket");

        group.MapGet("/{userName}", async (string userName, BasketService basketService) =>
        {
            var shoppingCart = await basketService.GetBasket(userName);
            if (shoppingCart is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(shoppingCart);
        })
            .WithName("GetBasket")
            .Produces<ShoppingCart>(StatusCodes.Status200OK)
            .RequireAuthorization();

        group.MapPost("/", async (ShoppingCart shoppingCart, BasketService basketService) =>
        {
            await basketService.UpdateBasket(shoppingCart);
            return Results.Created("GetBasket", shoppingCart);
        })
        .WithName("UpdateBasket")
        .Produces<ShoppingCart>(StatusCodes.Status201Created)
        .RequireAuthorization();

        group.MapDelete("/{userName}", async (string userName, BasketService basketService) =>
        {
            await basketService.DeleteBasket(userName);
            return Results.NoContent();
        })
            .WithName("DeleteBasket")
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization();
    }

    
}
