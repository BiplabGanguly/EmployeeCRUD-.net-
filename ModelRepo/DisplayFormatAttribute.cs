using System;

namespace ModelRepo
{
    internal class DisplayFormatAttribute : Attribute
    {
        public string DataFormatString { get; set; }
    }
}