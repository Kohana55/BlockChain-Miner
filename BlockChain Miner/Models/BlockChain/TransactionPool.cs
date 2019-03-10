using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Models.BlockChain
{
    public class TransactionPool
    {

        List<Transaction> transactionsList = new List<Transaction>();


        public TransactionPool()
        { }


        public void AddTransaction(Transaction transaction)
        {
            // Check before adding
            transactionsList.Add(transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            // Cycle transactionList and delete matching transaction
        }

    }
}
