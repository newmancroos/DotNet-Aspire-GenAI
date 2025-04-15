
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();


builder.AddNpgsqlDbContext<ProductDbContext>(connectionName: "catalogdb");
builder.Services.AddScoped<ProductService>();
var app = builder.Build();



// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();
//if(app.Environment.IsDevelopment())
app.UseMigration(); // It is an extension menthod to trigger migration
app.MapProductEndpoints();
app.UseHttpsRedirection();

app.Run();
