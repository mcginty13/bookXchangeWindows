using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookXchangeWindows
{
    class User
    {
        private string mID;
        private string mName;
        private string mEmail;
        private string mCourse;
        private int mYear;
        private List<Book> booksRequested;
        private List<Book> booksForSale;


        public User(string pID ,string pName, string pEmail, string pCourse, int pYear)
        {
            string mID = pID;
            string mName = pName;
            string mEmail = pEmail;
            string mCourse = pCourse;
            int mYear = pYear;
            booksRequested = new List<Book>();
            booksForSale = new List<Book>();
        }
    }   
}
