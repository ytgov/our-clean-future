using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Extensions;

public static class StringExtensions
{
    public static string? Truncate(this string? value, int maxLength, string truncationSuffix = "…")
    {
        return value?.Length > maxLength
            ? string.Concat(value.AsSpan(0, maxLength), truncationSuffix)
            : value;
    }
}
