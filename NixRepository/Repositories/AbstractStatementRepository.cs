using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using NiRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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


        public List<TEntity> GetStatement(int chargeMethodNumber, DateTime startDate, DateTime endDate)
        {
            //return context.Set<TEntity>().Where(
            //    x => x.ClientId == clientId
            //    && x.PurchaseDate >= startDate
            //    && x.PurchaseDate <= endDate
            //    )
            //    .Select(x => x).ToList();
            return null;
        }



        public async Task Save(TEntity entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
