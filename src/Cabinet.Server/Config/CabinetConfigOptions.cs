using Cabinet.Server.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cabinet.Server.Config
{
    public enum Platform
    {
        Win,
        Unix
    }

    public class CabinetConfigOptions
    {
        [Description("Directory where Cabinet Data is stored")]
        [DefaultValue(@"/var/cabinet.datadir;C:\\Cabinet.DataDir")]
        public string DataDir { get; set; }

        [Description("Flash document lifespan duration")]
        [DefaultValue(86400L)]
        public long FlashDuration { get; set; }

        [Description("Mime Types supported by Cabinet")]
        [DefaultValue("")]
        public Dictionary<string, string> MimeTypes { get; set; }

        public static object GetDefaultValue<T>(Expression<Func<CabinetConfigOptions, T>> expr)
        {
            var prop = expr.ToProperty();
            return prop.GetCustomAttributes<DefaultValueAttribute>().FirstOrDefault()?.Value;
        }
    }
}