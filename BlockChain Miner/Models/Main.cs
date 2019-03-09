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
        public BlockChainObj lewCoins;
        P2PClient client;


        /// <summary>
        /// Entry point for our programme
        /// 
        /// (Business logic, code behind, models...
        /// ...whatever you kids are calling it these days)
        /// </summary>
        public Main()
        {
            lewCoins = new BlockChainObj();
            client = new P2PClient(1007);
            client.OnMessageReceived += Client_OnMessageReceived;
            try
            {
                Task.Run(() => client.Start());
            }
            catch(Exception ex)
            {

            }
        }

        private void Client_OnMessageReceived()
        {
            // TEST CODE - Client connected to server and recived a message, send one back
            client.Send("Hello to you to");
        }
    }
}
