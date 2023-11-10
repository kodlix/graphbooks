using GraphQLBooks.GraphQL;
using GraphQLBooks.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().
    AddQueryType<Query>()
    .AddInterfaceType<IReadingMaterials>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>();

builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();
app.UseWebSockets();

app.Run();
