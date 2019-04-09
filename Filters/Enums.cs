using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZWebApplication.Filters
{
    public enum GZFilterMode
    {
        Undefined,
        Equal,
        NotEqual,
        Null,
        NotNull,
        Like,
        StartsWith,
        EndsWith
    }
}