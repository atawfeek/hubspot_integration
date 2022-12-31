using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubspot_integration
{
    public class ContactModel
    {
        public List<Property>? properties { get; set; }
    }

    public class Property
    {
        public string? property { get; set; }
        public string? value { get; set; }
    }
}
