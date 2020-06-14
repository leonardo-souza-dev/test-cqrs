using System;
using System.Collections.Generic;
using TestCQRS.Domain.Entities;

namespace TestCQRS.Domain.Repositories
{
    public interface ITransacaoRepository
    {
        List<Transaction> ObterTransacoes(DateTime data);
        Transaction Salvar(string descricao, decimal valor, DateTime data);
    }
}