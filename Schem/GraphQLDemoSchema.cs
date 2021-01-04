using Graphql.Net.Query;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Graphql.Net.Schem
{
    public class GraphQLDemoSchema : Schema
    {
        public GraphQLDemoSchema(IServiceProvider provider) :base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
        }
    }
}
