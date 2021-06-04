using Domain.Models;
using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using NixUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;

namespace NixRepository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly NixContext _context;

        public ClientRepository(NixContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClient<TEntity>(Expression<Func<TEntity, bool>> paymentMethodExpression) where TEntity : BaseAccount
        {
            var client = await _context.Set<TEntity>().Where(paymentMethodExpression).Join(
                    _context.Clients,
                    d => d.ClientId,
                    c => c.Id,
                    (d, c) => new Client
                    {
                        ClientName = c.ClientName,
                        CreditCardLimit = c.CreditCardLimit,
                        CreditCardNumber = c.CreditCardNumber,
                        AccountNumber = c.AccountNumber,
                        Funds = c.Funds,
                        Id = c.Id
                    }).FirstOrDefaultAsync();

            if (client == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "Método de pagamento não encontrado para o cliente.");

            return client;
        }

        public async Task SaveAsync(Client client)
        {
            try
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError, "Falha de comunicação com o banco de dados.");
            }
        }

        public async Task<Client> GetClient(int clientId)
        {
            try
            {
                return await _context.Clients.Where(x => x.Id == clientId).Select(x => x).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError, "Falha na comunicação com o banco de dados.");
            }
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }
    }
}
