using System;
using System.Collections.Generic;

namespace Cabinet.Server.Extensions
{
    public static class DocumentExtensions
    {
        public static string ToPublicUrl(this string self, string baseUrl)
            => self.Replace(baseUrl, "");

        public static string ToMimeType(this string self, Dictionary<string, string> mimeTypes)
            => mimeTypes.TryGetValue(self, out var mime)
                  ? mime : throw new ArgumentNullException(self);
    }
}