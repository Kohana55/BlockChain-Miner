using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockChain.Models.BlockChain;
using BlockChain.Models.Networking;

namespace BlockChain.Models
{
    public class Main
    {
        /// <summary>
        /// Client and Miner
        /// The Miner uses the client. 
        /// Both should run in their own threads
        /// </summary>
        public P2PClient client;
        public Miner miner;


        /// <summary>
        /// Entry point for our programme
        /// 
        /// (Business logic, code behind, models...
        /// ...whatever you kids are calling it these days)
        /// </summary>
        public Main()
        {          
            client = new P2PClient(1002);
            miner = new Miner(client);

            try
            {
                Task.Run(() => client.Start());
                Task.Run(() => miner.Start());
            }
            catch(Exception ex)
            {

            }
        }
    }
}
