using System;
using System.Text;
using System.Collections.Generic;


namespace FuelAccountModel.Domain {
    
    public partial class Fuel {
        public Fuel() { }
        public virtual int FuelId { get; set; }
        public virtual string Name { get; set; }
    }
}
