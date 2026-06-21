using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trade.Domain.Entities;

namespace Trade.persistence.Seeders
{
    public class OrderSeeder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.HasData(
                new Order
                {
                    Id = 1,
                    Symbol = "AAPL",
                    side = Domain.Enums.OrderSIde.buy,
                    transcTime = DateTime.UtcNow,
                    quantity = 100,
                    type = Domain.Enums.OrderType.market,
                    price = 150.00m
                },
                new Order
                {
                    Id = 2,
                    Symbol = "GOOGL",
                    side = Domain.Enums.OrderSIde.sell,
                    transcTime = DateTime.UtcNow,
                    quantity = 50,
                    type = Domain.Enums.OrderType.limit,
                    price = 2800.00m
                },
                new Order
                {
                    Id = 3,
                    Symbol = "MSFT",
                    side = Domain.Enums.OrderSIde.buy,
                    transcTime = DateTime.UtcNow,
                    quantity = 200,
                    type = Domain.Enums.OrderType.market,
                    price = 300.00m
                },
                new Order
                {
                    Id = 4,
                    Symbol = "AMZN",
                    side = Domain.Enums.OrderSIde.sell,
                    transcTime = DateTime.UtcNow,
                    quantity = 30,
                    type = Domain.Enums.OrderType.limit,
                    price = 3500.00m
                }
            );
        }
    }
}

/*
 * Como buena practica se tiene que crear un Seeder por cada entidad, 
 * esto con el fin de mantener el codigo organizado y facil de mantener, 
 * ademas de que cada Seeder se encarga de poblar la tabla correspondiente con datos de prueba, 
 * lo cual es muy util para el desarrollo y las pruebas de la aplicacion.
*/