using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bookXchangeWindows
{
    class Book
    {
        string mID;
        string mISBN;
        string mTitle;
        string mSubtitle;
        string mDescr;
        int? mPageCount;
        string mCategory;
        string mImgURL;
        bool isRequested;
        bool isForSale;
        
        public Book(string pID, string pISBN, string pTitle, string pDescr, string pCategory)
        {
            mID = pID;
            mISBN = pISBN;
            mTitle = pTitle;
            mDescr = pDescr;
            mCategory = pCategory;
        }
        
        public Book(BookModel pBookModel)
        {
            mID = pBookModel.Id;
            mTitle = pBookModel.Title;
            mSubtitle = pBookModel.Subtitle;
            mDescr = pBookModel.Description;
            mPageCount = pBookModel.PageCount;
            mImgURL = pBookModel.ImgLinks;


        }

        public string GetTitle() { return mTitle; }
        public string GetSubtitle() { return mSubtitle; }
        public string GetDescription() { return mDescr; }
        public string GetImageURL() { return mImgURL; }
        public int? GetPageCount() { return mPageCount; }
    }
}
