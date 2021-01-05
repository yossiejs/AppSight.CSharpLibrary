using System;
using System.Collections.Generic;
using System.Text;

namespace AppSight.AutoUpdate
{
    public class UpdateFoundEventArgs : EventArgs
    {
        public string Uri { get; set; }
        public string Version { get; set; }
    }
}
