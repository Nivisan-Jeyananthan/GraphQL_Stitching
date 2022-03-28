namespace LocalAuthority.GraphQL.Queries
{
    public class LocalAuthorityType : ObjectType<TnPolitischeGemeinde>
    {
        protected override void Configure(IObjectTypeDescriptor<TnPolitischeGemeinde> descriptor)
        {
            descriptor.Ignore(field => field.PgemBezId);
            descriptor.Ignore(field => field.PgemPregId);
        }
    }
}
