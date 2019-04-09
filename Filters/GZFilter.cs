using Newtonsoft.Json;
using NJsonSchema.Annotations;
using NJsonSchema.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GZWebApplication.Filters
{
    public interface IGZFilter
    {
        bool IsValid { get; }
    }

    [JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
    [KnownType(typeof(GZFilter<string>))]
    [JsonSchemaFlatten]
    public abstract class GZFilter<T> : IGZFilter
    {
        protected GZFilter()
            : this(default(T))
        {
        }

        protected GZFilter(T value)
        {
            Value = value;
            Mode = GZFilterMode.Equal;
        }

        public abstract IEnumerable<GZFilterMode> SupportedModes { get; }

        public abstract bool IsValid { get; }

        public virtual void Validate(GZFilterMode allowedAndDefaultMode)
        {
            Validate(new GZFilterMode[] { allowedAndDefaultMode }, allowedAndDefaultMode);
        }

        public virtual void Validate(IEnumerable<GZFilterMode> allowedModes, GZFilterMode defaultMode)
        {
            if (Mode == GZFilterMode.Undefined)
            {
                if (!SupportedModes.Contains(defaultMode))
                    throw new InvalidOperationException($"Default Mode {defaultMode} is not supported");

                Mode = defaultMode;
            }

            if (!allowedModes.Contains(Mode))
            {
                Mode = GZFilterMode.Undefined;
            }
        }

        public T Value { get; set; }

        public GZFilterMode Mode { get; set; }

        public string Text { get; set; }

        public string ToString(string propertyName)
        {
            return $"{propertyName}${ToString()}";
        }
    }
}