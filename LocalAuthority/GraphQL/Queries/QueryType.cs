namespace LocalAuthority.GraphQL.Queries
{
    public class QueryType : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor
                .Field("localAuthorities")
                .UsePaging<LocalAuthorityType>(options: new HotChocolate.Types.Pagination.PagingOptions
                {
                    MaxPageSize = 1000
                })
                .UseFiltering()
                .UseSorting()
                .Resolve((context) =>
                {
                    var dbContext = context.Service<BISSContext>();
                    return dbContext.TnPolitischeGemeindes;
                })
                .Type<NonNullType<ListType<NonNullType<LocalAuthorityType>>>>()

                ;
        }
    }
}
