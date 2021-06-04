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

        IEnumerable<TEntity> GetStatements();
    }
}
