using System;
using System.Collections.Generic;
using System.Text;

namespace AppSight.AutoUpdate
{
    public class Release
    {
        public string Uri { get; set; }
        public string Version { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
