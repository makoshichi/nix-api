using Domain.Models;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NixRepository
{
    public interface IClientRepository
    {
        // Como não há autenticação, obtem-se o cliente a partir do número da conta ou cartão
        Task<Client> GetClient(Expression<Func<Client, bool>> paymentMethodExpression);

        Task<Client> GetClient(int clientId);

        IEnumerable<Client> GetClients();

        Task SaveAsync(Client client);
    }
}
