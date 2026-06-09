using System;
using System.Collections.Generic;
using System.Text;
using Trade.Domain.Commons;
using Trade.Domain.Enums;

namespace Trade.Domain.Events
{
    public class OrderUpdatedEvent : BaseEvent
    {
        public String id {  get; set; }
        public int quantity { get; set; }
        public OrderType type { get; set; }
        public decimal price { get; set; }
    }
}
