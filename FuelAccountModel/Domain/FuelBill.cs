using System;
using System.Text;
using System.Collections.Generic;


namespace FuelAccountModel.Domain {
    
    public partial class FuelBill {
        public virtual int FuelBillId { get; set; }
        public virtual double? Payment { get; set; }
        public virtual int? FuelStationId { get; set; }
        public virtual DateTime BillDate { get; set; }
        public virtual float FuelPrice { get; set; }
        public virtual int FuelId { get; set; }
        public virtual TimeSpan? BillTime { get; set; }
        public virtual float? Discount { get; set; }
        public virtual float Litres { get; set; }
        public virtual float? Kilometrage { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual FuelStation FuelStation { get; set; }
    }
}
