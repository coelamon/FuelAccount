using System;
using System.Text;
using System.Collections.Generic;


namespace FuelAccountModel.Domain {
    
    public partial class FuelStation {
        public FuelStation() { }
        public virtual int FuelStationId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
    }
}
