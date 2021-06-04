using Domain.Context;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NixRepository.Repositories
{
    public class CreditAccountRepository<TEntity> : FinantialAccountRepository<TEntity>, IFinancialAccountRepository<TEntity>
        where TEntity : BaseAccount
    {
        public CreditAccountRepository(NixContext context) : base(context)
        {
        }

        public override IEnumerable<TEntity> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
