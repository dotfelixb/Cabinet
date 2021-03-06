﻿using System;

namespace Cabinet.Server.Model
{
    public class CabinetFileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; } // TODO : Normalize file path
        public string ContainerName { get; set; }
        public string DocumentName { get; set; }
        public long Size { get; set; }
        public string PublicUrl { get; set; }
        public string MimeType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}