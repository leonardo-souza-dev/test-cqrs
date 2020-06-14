using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCQRS.Domain.Entities;
using TestCQRS.Queries;

namespace TestCQRS.App.Impl
{
    public class TransacaoService : ITransacaoService
    {
        public async Task<List<Transaction>> ObterTransacoes(DateTime data)
        {
            return await Task.FromResult( new List<Transaction> 
            {
                new Transaction(data, "Café", 4, true),
                new Transaction(data, "Livro", 40, true)
            });
        }
    }
}
