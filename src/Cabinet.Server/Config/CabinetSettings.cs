using Cabinet.Server.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Cabinet.Server.Config
{
    public class CabinetSettings
    {
        private IConfigurationRoot config;

        public CabinetSettings(IConfigurationRoot config)
        {
            this.config = config;

            DataDir = config.GetSection("Datadir").GetValue(v => v.DataDir.GetPlatformLocation());
            FlashDuration = config.GetSection("FlastDur").GetValue(v => v.FlashDuration);
        }

        #region Settings Properties
        public DirectoryInfo    DirectoryInfo{ get; set; }
        public string DataDir { get; }
        public long FlashDuration { get; } 
        #endregion
    }
}