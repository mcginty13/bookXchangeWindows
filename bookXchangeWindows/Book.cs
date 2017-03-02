using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bookXchangeWindows
{
    class Book
    {
        private string mID;
        private string mISBN;
        private string mTitle;
        private string mSubtitle;
        private string mDescr;
        private string mAuthor;
        private int? mPageCount;
        private IList<string> mCategory;
        private string mImgURL;
        private bool isRequested;
        private bool isForSale;
        
        public Book(string pID, string pISBN, string pTitle, string pDescr, IList<string> pCategory)
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
            mISBN = pBookModel.ISBN;
            mTitle = pBookModel.Title;
            mSubtitle = pBookModel.Subtitle;
            mDescr = pBookModel.Description;
            mPageCount = pBookModel.PageCount;
            mImgURL = pBookModel.ImgLinks;
            mCategory = pBookModel.Categories;
            mAuthor = pBookModel.Author;


        }

        public string GetID() { return mID; }
        public string GetISBN() { return mISBN; }
        public string GetTitle() { return mTitle; }
        public string GetSubtitle() { return mSubtitle; }
        public string GetDescription() { return mDescr; }
        public string GetAuthor() { return mAuthor; }
        public string GetImageURL() { return mImgURL; }
        public int? GetPageCount() { return mPageCount; }
    }
}
