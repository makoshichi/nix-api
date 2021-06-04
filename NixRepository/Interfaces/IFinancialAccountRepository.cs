using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NixRepository
{
    public interface IFinancialAccountRepository<TEntity> where TEntity : BaseAccount
    {
        Task SaveAsync(TEntity entity);

        IEnumerable<TEntity> GetStatement(int clientId, DateTime startDate, DateTime endDate);

        IEnumerable<TEntity> GetStatements();
    }
}
