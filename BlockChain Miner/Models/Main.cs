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
        /// Lew Coins!!!! 
        /// </summary>
        public Miner lewCoins;
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
            
            client = new P2PClient(1005);
            miner = new Miner(client);
            lewCoins = new Miner(client);

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
