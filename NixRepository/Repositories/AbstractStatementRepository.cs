using Domain.Models.Base;
using NiRepository.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NixRepository.Repositories
{
    public abstract class AbstractStatementRepository<TEntity> : IStatementRepository<TEntity>
        where TEntity : BaseAccount
    {

        protected NixContext context;

        public AbstractStatementRepository(NixContext context)
        {
            this.context = context;
        }

        public abstract IEnumerable<TEntity> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate);

        public IEnumerable<TEntity> GetStatements()
        {
            return context.Set<TEntity>();
        }

        public async Task SaveAsync(TEntity entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
