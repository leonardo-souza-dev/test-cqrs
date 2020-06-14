using System;
using System.Collections.Generic;
using TestCQRS.Domain;
using System.Threading.Tasks;
using TestCQRS.Domain.Entities;

namespace TestCQRS.Queries
{
    public interface ITransacaoService
    {
        Task<List<Transaction>> ObterTransacoes(DateTime data);
    }
}
