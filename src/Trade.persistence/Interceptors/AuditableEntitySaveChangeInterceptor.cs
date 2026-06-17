using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Trade.Domain.Commons;

namespace Trade.persistence.Interceptors
{
    public class AuditableEntitySaveChangeInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext? context) {
        
            if(context == null) return;

            foreach (var Entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (Entry.State == EntityState.Added)
                {
                    Entry.Entity.CreatedBy = "System";
                    Entry.Entity.CreatedDate = DateTime.UtcNow;
                }

                if(Entry.State == EntityState.Modified) {
                    Entry.Entity.LastModifiedBy = "System";
                    Entry.Entity.LastModifiedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
