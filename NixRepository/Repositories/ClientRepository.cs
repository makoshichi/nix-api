using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using NixUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Data.SqlClient;

namespace NixRepository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly NixContext _context;

        public ClientRepository(NixContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClient(Expression<Func<Client, bool>> paymentMethodExpression)
        {
            Client client;
            try
            {
                client = await _context.Clients.Where(paymentMethodExpression).FirstOrDefaultAsync();
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }

            if (client == null)
                throw new HttpResponseException(HttpStatusCode.NotFound, "Método de pagamento não encontrado para o cliente.");

            return client;
        }

        public async Task SaveAsync(Client client)
        {
            var exists = await _context.Clients.AnyAsync(x => x.CreditCardNumber == client.CreditCardNumber || x.AccountNumber == client.AccountNumber);
            if (exists)
                throw new HttpResponseException(HttpStatusCode.BadRequest, "Número de conta ou cartão de crédito já existente.");

            try
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }
        }

        public async Task<Client> GetClient(int clientId)
        {
            try
            {
                return await _context.Clients.Where(x => x.Id == clientId).Select(x => x).FirstOrDefaultAsync();
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }
        }

        public IEnumerable<Client> GetClients()
        {
            try
            {
                return _context.Clients;
            }
            catch (SqlException)
            {
                throw new SqlCommFailureHttp500Exception();
            }
        }
    }
}
