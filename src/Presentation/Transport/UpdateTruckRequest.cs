using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Transport
{
    public class UpdateTruckRequest
    {
        public string Id { get; set; }
        public int Model { get; set; }

        public int ManufactoryYear { get; set; }

        public int ModelYear { get; set; }
    }
}
