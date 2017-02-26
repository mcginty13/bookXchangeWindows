using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookXchangeWindows
{
    abstract class Listing
    {
        string mListingID;
        string mListingISBN;
        string mUserID;
        DateTime mListedDate = new DateTime();
         
        public Listing(string pUserID, string pListingISBN)
        {
            mUserID = pUserID;
            mListingISBN = pListingISBN;
            mListedDate = DateTime.Now;
        }
    }
}
