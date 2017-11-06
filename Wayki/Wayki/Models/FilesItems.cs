using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wayki.Models
{
    public class FilesItems
    {
        public MediaFile Files { get; set; }
        public string TypeId { get; set; }
        public string Type { get; set; }
    }
}
