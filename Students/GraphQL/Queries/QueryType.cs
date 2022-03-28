using Students.Infrastructure;

namespace Students.GraphQL.Queries
{
    public class QueryType : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor
                .Field("students")
                .Resolve((context) =>
                {
                    var dbContext = context.Service<BISSContext>();
                    return dbContext.TLernenders;
                })
                .Type<NonNullType<ListType<NonNullType<StudentType>>>>()
                .UseFiltering()
                ;

        }
    }
}
