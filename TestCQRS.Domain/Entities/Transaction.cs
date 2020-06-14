using System;

namespace TestCQRS.Domain.Entities
{
    public class Transaction
    {
        public Transaction(DateTime data, string descricao, decimal valor, bool active)
        {
            Data = data;
            Descricao = descricao;
            Valor = valor;
            Active = active;
        }

        public decimal Valor { get; private set; }
        public DateTime Data { get;private set; }
        public string Descricao  { get;private set; }
        public bool Active { get; private set; }
    }
}
