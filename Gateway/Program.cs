using Gateway.GraphQL.Queries;
using Gateway.GraphQL.Stitching;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

const string myOrigin = "_myAllowSpecificOrigins";

services.AddCors(opt =>
             opt.AddPolicy(name: myOrigin, opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

services.AddHttpClient(WellknownSchemaNames.Students, c => c.BaseAddress = new Uri("https://localhost:5002/graphql"));
services.AddHttpClient(WellknownSchemaNames.LocalAuthorities, c => c.BaseAddress = new Uri("https://localhost:5005/graphql"));


services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddRemoteSchema(WellknownSchemaNames.LocalAuthorities)
    .AddRemoteSchema(WellknownSchemaNames.Students, ignoreRootTypes: true)
    .AddTypeExtensionsFromFile("./GraphQL/Stitching/Services.graphql")
    .AddFiltering()
    .AddSorting()
    ;

var app = builder.Build();
app.UseCors(myOrigin);
app.MapGraphQL();

app.Run();
