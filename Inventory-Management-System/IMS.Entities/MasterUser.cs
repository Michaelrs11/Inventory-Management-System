using System;
using System.Collections.Generic;

namespace IMS.Entities
{
    public partial class MasterUser
    {
        public string UserCode { get; set; } = null!;
        public int UserRoleEnumId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual UserRoleEnum UserRoleEnum { get; set; } = null!;
    }
}
