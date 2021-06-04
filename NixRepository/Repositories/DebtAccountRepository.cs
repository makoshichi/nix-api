using Domain.Context;
using Domain.Models.Base;

namespace NixRepository.Repositories
{
    public class DebtAccountRepository<TEntity> : FinantialAccountRepository<TEntity>, IFinancialAccountRepository<TEntity>
        where TEntity : BaseFinancialAccount
    {
        public DebtAccountRepository(NixContext context) : base(context)
        {
        }
    }
}
