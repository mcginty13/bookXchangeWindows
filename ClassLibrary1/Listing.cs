﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable()]
    public class Listing : ISerializable
    {
      private string mListingID;
      private string mBookID;
      private string mUserID;
      private DateTime mListedDate = new DateTime();
      private string mListedDateString;
      private bool mIsRequest;
      private int mPrice;

        public Listing() { }

        public Listing(string pUserID, string pBookID, bool pIsRequest, int pPrice)
        {
            mUserID = pUserID;
            mBookID = pBookID;
            mListedDate = DateTime.Now;
            mIsRequest = pIsRequest;
            mPrice = pPrice;
        }

        public Listing(User pUser, Book pBook, bool pIsRequest, int pPrice)
        {
            mListingID = "1"; // test value
            mBookID = pBook.GetID();
            mUserID = pUser.GetID();
            mListedDate = DateTime.Now;
            mIsRequest = pIsRequest;
            mPrice = pPrice;
        }
        public string GetBookID() { return mBookID; }

        //serialization methods


        //This serializes the object
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            mListedDateString = mListedDate.ToString();
            info.AddValue("ID", mListingID, typeof(string));
            info.AddValue("bookID", mBookID, typeof(string));
            info.AddValue("userID", mUserID, typeof(string));
            info.AddValue("listedDate", mListedDateString, typeof(string));
            info.AddValue("isRequest", mIsRequest);
            info.AddValue("price", mPrice, typeof(int));
        }
        //deserializes the stream in to a new object
        public Listing(SerializationInfo info, StreamingContext context)
        {
            mListingID = (string)info.GetValue("ID", typeof(string));
            mBookID = (string)info.GetValue("bookID", typeof(string));
            mUserID = (string)info.GetValue("userID", typeof(string));
            mListedDateString = (string)info.GetValue("listedDate", typeof(string));
            mListedDate = Convert.ToDateTime(mListedDateString);
            mIsRequest = (bool)info.GetValue("isRequest", typeof(bool));
            mPrice = (int)info.GetValue("price", typeof(int));

        }
    }

    }
