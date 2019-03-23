using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Models.BlockChain
{
    /// <summary>
    /// This class will likely need a Critial Section
    /// </summary>
    public class TransactionPool
    {

        public List<Transaction> pendingTransactions = new List<Transaction>();
        public List<Transaction> processedTransactions = new List<Transaction>();


        public TransactionPool()
        { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        public void AddTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        public void DeleteTransactionFromPending(Transaction transaction)
        {
            pendingTransactions.Remove(transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        public void DeleteTransactionFromProcessed(Transaction transaction)
        {
            processedTransactions.Remove(transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        public void TransferTransactionToProcessed(Transaction transaction)
        {
            processedTransactions.Add(transaction);
            pendingTransactions.Remove(transaction);
        }

        /// <summary>
        /// Handles moving the transaction of a candidate
        /// block to the processed transactions list
        /// </summary>
        /// <param name="candidateBlock"></param>
        public void ProcessCandidateBlock(Block candidateBlock)
        {
            for(int i = 0; i < candidateBlock.transactions.Count; i++)
            {
                TransferTransactionToProcessed(candidateBlock.transactions[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateBlock"></param>
        public void ProcessSucessfulCandidateBlock(Block candidateBlock)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateBlock"></param>
        public void ProcessFailedCandidateBlock(Block candidateBlock)
        {

        }
    }
}
