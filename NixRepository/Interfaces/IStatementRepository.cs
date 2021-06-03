using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NixRepository
{
    public interface IStatementRepository<TEntity> where TEntity : BaseAccount
    {
        Task Save(TEntity entity);
        List<TEntity> GetStatement(int clientId, DateTime startDate, DateTime endDate);
    }
}
