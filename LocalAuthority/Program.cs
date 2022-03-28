using LocalAuthority.GraphQL.Queries;
using LocalAuthority.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
const string myOrigin = "_allowAllorigin";

services.AddDbContext<BISSContext>();
services.AddCors(opt =>
             opt.AddPolicy(name: myOrigin, opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

services
    .AddGraphQLServer()
      .RegisterService<BISSContext>(ServiceKind.Synchronized)
    //.AddType<TnPolitischeGemeinde>()
    //.AddType<QueryType>()
    .AddQueryType<Query>()
    .AddFiltering()
    .AddSorting()
    .InitializeOnStartup()
    .PublishSchemaDefinition(descriptor => descriptor
    .SetName("local_authorities")
    .IgnoreRootTypes()
    .AddTypeExtensionsFromFile("./GraphQL/Stitching/Services.graphql"))
    ;

var app = builder.Build();

app.MapGraphQL();
app.UseCors(myOrigin);

app.Run();
