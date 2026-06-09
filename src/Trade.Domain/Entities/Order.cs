using System;
using System.Collections.Generic;
using System.Text;
using Trade.Domain.Commons;
using Trade.Domain.Enums;

namespace Trade.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public string Symbol { get; set; }

        public OrderSIde side { get; set; }

        public DateTime transcTime { get; set; }

        public int quantity { get; set; }

        public OrderType type { get; set; }

        public decimal price { get; set; }
    }
}
