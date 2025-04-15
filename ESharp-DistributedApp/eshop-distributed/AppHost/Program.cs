var builder = DistributedApplication.CreateBuilder(args);


//Backing Services
var postgres = builder
    .AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

//This will create a Postgres container with optional PgAdmin UI tool and a data volume for persistence. so eventhough we stop running the 
//project the container will run and data will be persisted.

var cache = builder
     .AddRedis("cache")
     .WithRedisInsight()
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var catalogDb = postgres.AddDatabase("catalogdb");
// This will not create database in the postgres container.
// We need to create it manually but it will be a connection string to the database we created above.



//Projects
var catalog = builder
    .AddProject<Projects.Catalog>("catalog")
    .WithReference(catalogDb)
    .WaitFor(catalogDb);

// This will inject environment variable to the service (here it is catalog) with the connection string to the database we created above.

// Add projects and cloud-native backing services here


builder
    .AddProject<Projects.Basket>("basket")
    .WithReference(cache)
    .WaitFor(cache);

// This will inject environment variable to the service (here it is catalog) with the connection string to the database we created above.

// Add projects and cloud-native backing services here


builder.Build().Run();
