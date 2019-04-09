using Newtonsoft.Json;
using NJsonSchema.Annotations;
using NJsonSchema.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GZWebApplication.Filters
{
    [JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [KnownType(typeof(GZFilter<int?>))]
    [JsonSchemaFlatten]
    public class GZIntFilter : GZFilter<int?>
    {
        public GZIntFilter()
        {
        }

        public GZIntFilter(int? value)
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
        };

        public override bool IsValid
        {
            get
            {
                switch (Mode)
                {
                    case GZFilterMode.Equal:
                    case GZFilterMode.NotEqual:
                        return Value.HasValue;

                    case GZFilterMode.Null:
                    case GZFilterMode.NotNull:
                        return true;

                    default:
                        return false;
                }
            }
        }
    }
}