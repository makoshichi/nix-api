using Domain.Models;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NixRepository
{
    public interface IClientAccountRepository
    {
        // Como optei por não usar Id do banco como número da conta/número cartão, achou-se necessário criar uma forma de obter o Id do cliente
        Task<Client> GetClient<TEntity>(Expression<Func<TEntity, bool>> chargeMethodExpression) where TEntity : BaseAccount;

        Task<Client> GetClient(int clientId);

        List<Client> GetClients();
    }
}
