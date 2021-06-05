using Domain.Models.Base;
using Domain.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using NixUtil.Exceptions;
using System.Net;
using Microsoft.Data.SqlClient;

namespace NixRepository.Repositories
{
    public class FinantialAccountRepository<TEntity> : IFinancialAccountRepository<TEntity>
        where TEntity : BaseFinancialAccount
    {

        protected NixContext context;

        public FinantialAccountRepository(NixContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> GetStatements()
        {
            try
            {
                return context.Set<TEntity>();
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }
        }

        public async Task SaveAsync(TEntity entity)
        {
            try
            {
                context.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }

        }
    }
}
