using System;
using System.Collections.Generic;
using System.Text;
using Trade.Domain.Commons;

namespace Trade.Domain.Events
{
    public class OrderCaledEvent : BaseEvent
    {
        public int Id { get; set; }
    }
}
