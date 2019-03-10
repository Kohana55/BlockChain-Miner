using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Models.BlockChain
{
    public class Transaction
    {

        public string sender;
        public string receiver;
        public string amount;
        public DateTime dateTime;
        public string transactionHash;


        /// <summary>
        /// Construct a Transaction from a network message
        /// </summary>
        /// <param name="netWorkTransaction"></param>
        public Transaction(string netWorkTransaction)
        {
            Deserialise(netWorkTransaction);
        }

        /// <summary>
        /// Constructs a transaction
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Receiver"></param>
        /// <param name="Amount"></param>
        public Transaction(string Sender, string Receiver, string Amount, DateTime dateTime)
        {
            sender = Sender;
            receiver = Receiver;
            amount = Amount;
            dateTime = DateTime.Now;
            RunHash();
        }


        /// <summary>
        /// Runs a hash on this transaction that other nodes 
        /// can check against their transaction pools
        /// </summary>
        public void RunHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{dateTime}-{sender}-{receiver}-{amount}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            transactionHash = Convert.ToBase64String(outputBytes);
        }


        /// <summary>
        /// Returns this transaction as a string for sending on the network
        /// </summary>
        /// <returns></returns>
        public string Serialise()
        {
            return $"TRANSACTION:{sender},{receiver},{amount},{dateTime},{transactionHash}" + 0;
        }

        /// <summary>
        /// Parses network message and populates fields
        /// </summary>
        /// <param name="data"></param>
        public void Deserialise(string data)
        {
            string trimmedData = data.Substring(data.IndexOf(':')+1);
            string[] messageTokens = trimmedData.Split(',');

            sender = messageTokens[0];
            receiver = messageTokens[1];
            amount = messageTokens[2];

            // Parse DateTime
            string[] dateTimeTokens = messageTokens[3].Split(' ');
            string[] dateTokens = dateTimeTokens[0].Split('/');
            string[] timeTokens = dateTimeTokens[1].Split(':');

            dateTime = new DateTime(int.Parse(dateTokens[2]), int.Parse(dateTokens[1]), int.Parse(dateTokens[0]), 
                                    int.Parse(timeTokens[0]), int.Parse(timeTokens[1]), int.Parse(timeTokens[2]));


            transactionHash = messageTokens[4];
        }
    }
}
