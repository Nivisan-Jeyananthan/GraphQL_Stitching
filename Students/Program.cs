using Students.GraphQL.Queries;
using Students.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
const string myOrigin = "_myAllowSpecificOrigins";

services.AddDbContext<BISSContext>();
services.AddCors(opt =>
             opt.AddPolicy(name: myOrigin, opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

services
    .AddGraphQLServer()
      .RegisterService<BISSContext>(ServiceKind.Synchronized)
    .AddType<StudentType>()
    .AddType<QueryType>()
    .AddQueryType()
    .AddFiltering()
    .InitializeOnStartup()
    ;

var app = builder.Build();

app.MapGraphQL()
    ;

app.UseCors(myOrigin);
app.UseHttpsRedirection();
app.Run();
