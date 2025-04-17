
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();
builder.AddRedisDistributedCache(connectionName: "cache");
builder.Services.AddScoped<BasketService>();
builder.Services.AddMassTransitWithAssemblies(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient<CatalogApiClient>(client =>
{
    client.BaseAddress = new Uri("https+http://catalog");
});
builder.Services.AddAuthentication()
                .AddKeycloakJwtBearer(
                    "keycloak",
                    realm: "eshop",
                    configureOptions: options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.Audience = "account";
                    });
builder.Services.AddAuthorization();


var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();
app.MapBasketEndpoints();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
