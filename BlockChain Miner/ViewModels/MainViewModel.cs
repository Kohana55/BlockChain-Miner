using BlockChain.Models;
using BlockChain.UtilityObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain_Miner.ViewModels
{
    public class MainViewModel : BindableBase
    {

        Main main = new Main();

        public int NumberOfTransactions
        {
            get { return numberOfTransactions; }
            set { SetProperty(ref numberOfTransactions, value); }
        }
        private int numberOfTransactions;

        public string BlocksSuggestedAccepted
        {
            get { return blocksSuggested; }
            set { SetProperty(ref blocksSuggested, value); }
        }
        private string blocksSuggested;

        public string PreviousHash
        {
            get { return previousHash; }
            set { SetProperty(ref previousHash, value); }
        }
        private string previousHash;

        public int PreviousIndex
        {
            get { return previousIndex; }
            set { SetProperty(ref previousIndex, value); }
        }
        private int previousIndex;

        public string NetworkStatus
        {
            get { return networkStatus; }
            set { SetProperty(ref networkStatus, value); }
        }
        private string networkStatus;

        public MainViewModel()
        {

        }

    }
}
