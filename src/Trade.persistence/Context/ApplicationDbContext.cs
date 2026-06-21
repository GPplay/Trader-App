using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Trade.Domain.Entities;
using Trade.persistence.Interceptors;

namespace Trade.persistence.Context
{
    internal class ApplicationDbContext : DbContext // la clase DbCOntext detras implementa el patron Unit of Work, y el DbSet implementa el patron Repository
    {
        public readonly AuditableEntitySaveChangeInterceptor _auditableEntitySaveChangeInterceptor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                    AuditableEntitySaveChangeInterceptor auditableEntitySaveChangeInterceptor) : base(options) {
            {
                _auditableEntitySaveChangeInterceptor = auditableEntitySaveChangeInterceptor;
            }
        }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangeInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
}
}

/*
 * la case DbContext es la clase principal que se encarga de gestionar la conexion a la base de datos, 
 * y de mapear las entidades a las tablas de la base de datos, ademas de implementar el patron Unit of Work, 
 * que permite gestionar las transacciones de manera eficiente, y el DbSet implementa el patron Repository, 
 * que permite gestionar las operaciones CRUD de manera eficiente.
*/