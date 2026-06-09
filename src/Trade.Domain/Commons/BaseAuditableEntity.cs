using System;
using System.Collections.Generic;
using System.Text;

namespace Trade.Domain.Commons
{
    public abstract class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
