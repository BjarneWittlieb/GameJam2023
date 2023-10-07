using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Profiling.Memory.Experimental;

namespace Util.RoomGeneration
{
    public class RoomObjectType
    {
        public string Name { get; set; }
        public int MinimumAmount { get; set; }
        public int MaximumAmount { get; set; }


    }
}
