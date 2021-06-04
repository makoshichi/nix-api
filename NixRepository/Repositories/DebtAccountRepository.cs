using Domain.Context;
using Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace NixRepository.Repositories
{
    public class DebtAccountRepository<TEntity> : FinantialAccountRepository<TEntity>, IFinancialAccountRepository<TEntity>
        where TEntity : BaseAccount
    {
        public DebtAccountRepository(NixContext context) : base(context)
        {
        }

        public override IEnumerable<TEntity> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
