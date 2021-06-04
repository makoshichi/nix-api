﻿using Domain.Models;
using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Domain.Context;
using NixUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NixRepository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly NixContext _context;

        public ClientRepository(NixContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClient<TEntity>(Expression<Func<TEntity, bool>> chargeMethodExpression) where TEntity : BaseAccount
        {
            var client = await _context.Set<TEntity>().Where(chargeMethodExpression).Join(
                    _context.Clients,
                    d => d.ClientId,
                    c => c.Id,
                    (d, c) => new Client
                    {
                        ClientName = c.ClientName,
                        CreditCardLimit = c.CreditCardLimit,
                        Funds = c.Funds,
                        Id = c.Id
                    }).FirstOrDefaultAsync();

            if (client == null)
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound, "Método de pagamento não encontrado");

            return client;
        }


        public async Task<Client> GetClient(int clientId)
        {
            return await _context.Clients.Where(x => x.Id == clientId).Select(x => x).FirstOrDefaultAsync();
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;

        }
    }
}