using BlockChain.Models.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BlockChain.Models.BlockChain
{
    public class Miner
    {
        /// <summary>
        /// The Miner Manager holds a client and a transaction pool
        /// Between these it can build blocks and send them
        /// on the network to any clients connected
        /// </summary>
        public TransactionPool transactionPool;
        public P2PClient client;
        public string currentHash;
        public int currentIndex;
        public Block candidateBlock = null;


        /// <summary>
        /// 
        /// </summary>
        public Stopwatch hashTimer;

        /// <summary>
        /// Block Chain constructor
        /// Both creates the chain and the genesis block
        /// </summary>
        public Miner(P2PClient client)
        {
            this.client = client;
            client.OnMessageReceived += MessageReceivedFromClient;
            transactionPool = new TransactionPool();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            // Introduce a close flag to close gracefully 
            while (true)
            {
                if (transactionPool.pendingTransactions.Count >= 2)
                {
                    MineBlock();
                    transactionPool.ProcessCandidateBlock(candidateBlock);
                }

                Thread.Sleep(50);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void MineBlock()
        {
            candidateBlock = new Block(DateTime.Now, "", transactionPool.pendingTransactions);
            candidateBlock.previousHash = currentHash;
            candidateBlock.index = currentIndex;

            // This will block the thread in future when we make hashing take purposely longer
            candidateBlock.MineHash("Lew");

            // Candidate block complete, send on network
            client.Send(candidateBlock.Serialise());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        private void MessageReceivedFromClient(string message)
        {

            // Upgrade into a switch statement based off the first 2 characters

            if (message.Substring(0, "T:".Length) == "T:")
            {
                ProcessTransaction(message);
            }
            else if (message.Substring(0, "U:".Length) == "U:")
            {
                ProcessUpdate(message.Substring(message.IndexOf(':') + 1));
            }
            else if (message.Substring(0, "M:".Length) == "M:")
            {
                ProcessMessage(message);
            }
        }

        private void ProcessMessage(string message)
        {
            string trimmedMessage = message.Substring(message.IndexOf(':') + 1);

            if (message == "BlockAccepted")
            {
                // Remove transaction in candidate block from pool and null candidate block

            }
        }

        private void ProcessTransaction(string message)
        {
            transactionPool.AddTransaction(new Transaction(message));
        }

        private void ProcessUpdate(string update)
        {
            string[] tokens = update.Split(',');
            currentHash = tokens[0];
            currentIndex = int.Parse(tokens[1]);
            currentIndex++;
        }

        public delegate void OnStatusUpdateEventHandler(object sender, string e);
        public event OnStatusUpdateEventHandler StatusUpdate;
    }
}
