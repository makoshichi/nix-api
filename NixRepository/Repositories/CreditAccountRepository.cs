using Domain.Context;
using Domain.Models.Base;

namespace NixRepository.Repositories
{
    public class CreditAccountRepository<TEntity> : FinantialAccountRepository<TEntity>, IFinancialAccountRepository<TEntity>
        where TEntity : BaseAccount
    {
        public CreditAccountRepository(NixContext context) : base(context)
        {
        }
    }
}
