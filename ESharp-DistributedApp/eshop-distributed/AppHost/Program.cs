var builder = DistributedApplication.CreateBuilder(args);


//Backing Services
//----------------
var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()  // Limitation of Azure storage. // Comment this line when deploy to azure
    .WithLifetime(ContainerLifetime.Persistent);


//This will create a Postgres container with optional PgAdmin UI tool and a data volume for persistence. so eventhough we stop running the 
//project the container will run and data will be persisted.

var cache = builder
     .AddRedis("cache")
     .WithRedisInsight()
    .WithDataVolume()  // Comment this line when deploy to azure
    .WithLifetime(ContainerLifetime.Persistent);


var catalogDb = postgres.AddDatabase("catalogdb");
// This will not create database in the postgres container.
// We need to create it manually but it will be a connection string to the database we created above.


var rabbitmq = builder
    .AddRabbitMQ("rabbitmq")
    .WithManagementPlugin()
    .WithDataVolume()  // Comment this line when deploy to azure
    .WithLifetime(ContainerLifetime.Persistent);

var keycloak = builder
    .AddKeycloak("keycloak",8080)
    .WithDataVolume()   // Comment this line when deploy to azure
    //.WithExternalHttpEndpoints()  // Comment this line when deploy to azure
    .WithLifetime(ContainerLifetime.Persistent);

// Data Valunes don't work on ACA for postgres so only add when running. This indicate it is locval environment or docker environment
//// UnComment this line when deploy to azure
//if (builder.ExecutionContext.IsRunMode)
//{
//    postgres.WithDataVolume();
//    rabbitmq.WithDataVolume();
//    keycloak.WithDataVolume();
//    cache.WithDataVolume();
//}


//Projects
//----------------
var catalog = builder
    .AddProject<Projects.Catalog>("catalog")
    .WithReference(catalogDb)
    .WithReference(rabbitmq)
    .WaitFor(catalogDb)
    .WaitFor(rabbitmq);

// This will inject environment variable to the service (here it is catalog) with the connection string to the database we created above.

// Add projects and cloud-native backing services here

var basket = builder
    .AddProject<Projects.Basket>("basket")
    .WithReference(cache)
    .WithReference(catalog)
    .WithReference(rabbitmq)
    .WithReference(keycloak)
    .WaitFor(cache)
    .WaitFor(rabbitmq)
    .WaitFor(keycloak);

builder.AddProject<Projects.WebApp>("webapp")
    .WithExternalHttpEndpoints()
    .WithReference(catalog)
    .WithReference(basket)
    .WithReference(cache)
    .WaitFor(catalog)
    .WaitFor(basket);

builder.Build().Run();
