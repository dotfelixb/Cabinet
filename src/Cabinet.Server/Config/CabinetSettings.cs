using Cabinet.Server.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cabinet.Server.Config
{
    public class CabinetSettings
    {
        private IConfigurationRoot config;

        public CabinetSettings(IConfigurationRoot config)
        {
            this.config = config;

            DataDir = config.GetSection("Datadir")
                .GetValue(v => v.DataDir.GetPlatformLocation());

            FlashDuration = config.GetSection("FlastDur")
                .GetValue(v => v.FlashDuration);

            MimeTypes = config.GetSection("MimeTypes")
                .GetChildren().ToDictionary(m => m.Key, m => m.Value);
        }

        #region Settings Properties

        public DirectoryInfo DirectoryInfo { get; set; }
        public string DataDir { get; }
        public long FlashDuration { get; }
        public Dictionary<string, string> MimeTypes { get; set; }

        #endregion Settings Properties
    }
}