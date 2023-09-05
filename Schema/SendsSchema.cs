using GraphQL.Introspection;
using GraphQL.Types;
using System.Text.Json.Serialization.Metadata;
using System.Web.Mvc;

namespace GraphQLAPI.Schema
{
    public class SendsSchema : GraphQL.Types.Schema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        //    public SendsSchema(IServiceProvider sp)
        //    {
        //        this._schema = 

        //            _ =>
        //        {
        //            _.DependencyResolver = new FuncDependencyResolver(t => sp.GetService(t));
        //            _.Types.Include<MyQuery>();
        //        });
        //    }
    }
}