using Newtonsoft.Json;
using NJsonSchema.Annotations;
using NJsonSchema.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GZWebApplication.Filters
{
    [JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [KnownType(typeof(GZFilter<string>))]
    [JsonSchemaFlatten]
    public class GZStringFilter : GZFilter<string>
    {
        public GZStringFilter()
        {
        }

        public GZStringFilter(string value)
            : base(value)
        {
        }

        public override IEnumerable<GZFilterMode> SupportedModes =>
        new GZFilterMode[]
        {
            GZFilterMode.Equal,
            GZFilterMode.NotEqual,
            GZFilterMode.Null,
            GZFilterMode.NotNull,
            GZFilterMode.Like,
            GZFilterMode.StartsWith,
            GZFilterMode.EndsWith
        };

        public override bool IsValid
        {
            get
            {
                return true;
            }
        }
    }
}