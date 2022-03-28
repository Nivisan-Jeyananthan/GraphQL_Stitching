namespace LocalAuthority.GraphQL.Queries
{
    public class Query
    {
        public LocalAuthorityService GetLocalAuthorityService([Service] LocalAuthorityService localAuthorityQuery) => localAuthorityQuery;
    }
}
