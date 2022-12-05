using System;
using System.Collections.Generic;

namespace IMS.Entities
{
    public partial class MasterKategori
    {
        public MasterKategori()
        {
            MasterBarangs = new HashSet<MasterBarang>();
        }

        public string KategoriCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual ICollection<MasterBarang> MasterBarangs { get; set; }
    }
}
