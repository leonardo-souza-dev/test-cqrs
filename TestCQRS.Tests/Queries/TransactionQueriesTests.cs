using NUnit.Framework;
using TestCQRS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using TestCQRS.Domain.Queries;
using System;

namespace TestCQRS.Tests
{
    public class TransactionQueriesTests
    {
        List<Transaction> _transactions = new List<Transaction>();

        [SetUp]
        public void SetUp()
        {
            _transactions.Add(new Transaction(DateTime.Now, "Coffe", 2, true));
            _transactions.Add(new Transaction(DateTime.Now, "Coffe", 2, false));
        }

        [Test]
        public void Test1()
        {
            var result = _transactions.AsQueryable().Where(TransactionQueries.GetActiveTransactions());

            Assert.AreEqual(result.Count(), 1);
        }
    }
}