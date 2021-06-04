using Domain.Models.Base;
using Domain.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NixRepository.Repositories
{
    public abstract class FinantialAccountRepository<TEntity>
        where TEntity : BaseAccount
    {

        protected NixContext context;

        public FinantialAccountRepository(NixContext context)
        {
            this.context = context;
        }

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
