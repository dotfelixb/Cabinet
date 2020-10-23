using System;

namespace Cabinet.Server.Model
{
    public class CabinetFileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}