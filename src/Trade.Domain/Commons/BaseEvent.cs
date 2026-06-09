using System;
using System.Collections.Generic;
using System.Text;

namespace Trade.Domain.Commons
{
    public abstract class BaseEvent
    {
        public Guid? MessgeId { get; set; }
        public DateTime? publishTime { get; set; }
    }
}
