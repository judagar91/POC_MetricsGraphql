using GraphQLAPI.Models;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using System.Text.Json;

namespace GraphQLAPI.App.Schema
{
    public class UserSettingsTypeModule : ITypeModule
    {
        private readonly string _FileName;

        public event EventHandler<EventArgs> TypesChanged;

        private readonly FileSystemWatcher _watcher;

        public UserSettingsTypeModule(string fileName)
        {
            _FileName = fileName;

            _watcher = new FileSystemWatcher (System.IO.Path.GetDirectoryName(_FileName)!);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                | NotifyFilters.CreationTime
                | NotifyFilters.FileName
                | NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.Size;

            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += (sender, args) => TypesChanged?.Invoke(this, EventArgs.Empty);

        }

        public async ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(IDescriptorContext context, CancellationToken cancellationToken)
        {
            var types = new List<ITypeSystemMember> ();
            using var stream = File.OpenRead (_FileName);
            using var config = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);

            foreach (var typeConfig in config.RootElement.EnumerateArray())
            {
                var type = new ObjectTypeDefinition(typeConfig.GetProperty("name").ToString());
                foreach (var fieldConfig in typeConfig.GetProperty("fields").EnumerateArray())
                {
                    var field = new ObjectFieldDefinition(
                        fieldConfig.GetProperty("name").GetString()!,
                        type: TypeReference.Parse(fieldConfig.GetProperty("type").GetString()!));

                    var fieldDescriptor = ObjectFieldDescriptor.From(context, field);
                    fieldDescriptor.FromJson();
                    fieldDescriptor.CreateDefinition();

                    type.Fields.Add(field);
                }
                var settingsType = TypeReference.Create(new NonNullType((INamedType)types[0]));

                var user = new ObjectType<User>(
                    d =>
                    {
                        d.BindFieldsExplicitly();
                        d.Field(t => t.Name);
                        d.Field(t => t.Settings)
                            .Resolve(ctx =>
                            {
                                if (ctx.Parent<User>().Settings is string s)
                                {
                                    return JsonDocument.Parse(s).RootElement;
                                }
                                return null;
                            })
                            .Extend()
                            .Definition.Type = settingsType;
                    });
                types.Add(ObjectType.CreateUnsafe(type));
            }
            
            return types;
        }
    }
}
