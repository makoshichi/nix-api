using Domain.Context;
using Domain.Models.Base;

namespace NixRepository.Repositories
{
    public class DebtAccountRepository<TEntity> : FinantialAccountRepository<TEntity>, IFinancialAccountRepository<TEntity>
        where TEntity : BaseAccount
    {
        public DebtAccountRepository(NixContext context) : base(context)
        {
        }
    }
}
