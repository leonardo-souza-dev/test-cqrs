using System;
using System.Collections.Generic;
using TestCQRS.Domain.Entities;
using TestCQRS.Domain.Repositories;

public class FakeTransactionRepository : ITransacaoRepository
{
    public List<Transaction> ObterTransacoes(DateTime data)
    {
        throw new NotImplementedException();
    }

    public Transaction Salvar(string descricao, decimal valor, DateTime data)
    {
        throw new NotImplementedException();
    }
}