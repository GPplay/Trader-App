using System;
using System.Collections.Generic;
using System.Text;
using Trade.Domain.Commons;
using Trade.Domain.Enums;

namespace Trade.Domain.Events
{
    public class OrderCreatedEvent : BaseEvent
    {
        public int Id { get; set; }
        public String Symbol { get; set; }
        public OrderSIde side { get; set; }
        public DateTime TransactTime { get; set; }
        public int Quantity { get; set; }
        public OrderType type { get; set; }
        public decimal prices { get; set; }

    }
}