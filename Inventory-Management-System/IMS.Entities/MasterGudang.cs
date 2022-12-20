using System;
using System.Collections.Generic;

namespace IMS.Entities
{
    public partial class MasterGudang
    {
        public MasterGudang()
        {
            StockTransactions = new HashSet<StockTransaction>();
        }

        public string GudangCode { get; set; } = null!;
        public string OutletCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Outlet OutletCodeNavigation { get; set; } = null!;
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }
    }
}
