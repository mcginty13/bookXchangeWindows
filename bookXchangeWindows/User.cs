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
        private List<Book> bookRequested;
        private List<Book> bookForSale;


        public User(string pID ,string pName, string pEmail, string pCourse, int pYear)
        {
            string mID = pID;
            string mName = pName;
            string mEmail = pEmail;
            string mCourse = pCourse;
            int mYear = pYear;
            bookRequested = new List<Book>();
            bookForSale = new List<Book>();
        }
    }   
}
