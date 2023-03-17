using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_serialization___RAF
{
    [Serializable]
    internal class Event
    {
        public int EventNumber { get; set; }
        public string Location { get; set; }
    }
}
