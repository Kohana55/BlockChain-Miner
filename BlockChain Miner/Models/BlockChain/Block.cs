using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Models.BlockChain
{
    /// <summary>
    /// A Block 
    /// </summary>
    public class Block
    {

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
         * The fields needed for a block are;
         * 
         * An Index number
         * A Timestamp
         * The Hash Code of the previous block
         * Its own Hash Code
         * And of course, the "data" - in this case, a string with some value
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public int index;
        public DateTime date;
        public string previousHash;
        public string hash;
        public int nonce;
        public string data;

        /// <summary>
        /// Create a block using the date and the data
        /// The remaining information is set to null as it'll be replaced
        /// during the "AddBlock" process
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dataArg"></param>
        public Block(DateTime dt, string dataArg)
        {
            index = 0;
            date = dt;
            previousHash = null;
            hash = null;
            nonce = 0;
            data = dataArg;        
        }

        /// <summary>
        /// Generate a hash code using SHA256
        /// </summary>
        /// <returns>A string holding the hash value</returns>
        public string GenerateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{date}-{previousHash ?? ""}-{data}-{nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }

        /// <summary>
        /// Mines for a hash code that contains the input
        /// from user. 
        /// 
        /// If no input is entered, the nugget defaults to "Lew"
        /// Thus - "LewCoins"
        /// </summary>
        public void MineHash(string nugget)
        {
            // If nugget field is left blank, use "Lew"
            if (nugget == null)
                nugget = "Lew";

            // Mine for Hash
            bool hashMined = false;
            while (hashMined == false)
            {
                nonce++;
                hash = GenerateHash();

                for (int i = 0; (i < hash.Length - nugget.Length); i++)
                {
                    if (hash.Substring(i, nugget.Length) == nugget)
                        hashMined = true;
                }
            }
        }

    }
}
