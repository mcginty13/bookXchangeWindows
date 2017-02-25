using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bookXchangeWindows
{
    class Book
    {
        int mID;
        string mISBN;
        string mTitle;
        string mDescr;
        string mCategory;
        bool isRequested;
        bool isForSale;
        
        public Book(int pID, string pISBN, string pTitle, string pDescr, string pCategory)
        {
            mID = pID;
            mISBN = pISBN;
            mTitle = pTitle;
            mDescr = pDescr;
            mCategory = pCategory;
        }
        
        public Book(string pISBN)
        {
            mISBN = pISBN;

        }

        public void LookUpISBN()
        {
            
        }
    }
}
