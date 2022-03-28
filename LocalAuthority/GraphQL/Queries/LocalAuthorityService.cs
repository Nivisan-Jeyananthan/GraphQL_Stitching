using LocalAuthority.Infrastructure;

namespace LocalAuthority.GraphQL.Queries
{
    public class LocalAuthorityService
    {
        [UseFiltering]
        [UseSorting]
        public IEnumerable<TnPolitischeGemeinde> GetLocalAuthorities([Service] BISSContext dbcontext) => dbcontext.TnPolitischeGemeindes;
    }
}