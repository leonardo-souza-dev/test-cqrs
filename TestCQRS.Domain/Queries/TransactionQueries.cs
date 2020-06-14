using System;
using System.Linq.Expressions;
using TestCQRS.Domain.Entities;

namespace TestCQRS.Domain.Queries
{
    public static class TransactionQueries
    {
        public static Expression<Func<Transaction, bool>> GetActiveTransactions()
        {
            return x => x.Active;
        }
    }
}
