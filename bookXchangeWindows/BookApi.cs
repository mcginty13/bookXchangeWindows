using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Services;
using Google.Apis.Books.v1;

namespace bookXchangeWindows
{
    public class BookModel
    {
        public string Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Subtitle
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int? PageCount
        {
            get;
            set;
        }
        public string ImgLinks
        {
            get;
            set;
        }
    }

    public class BookApi
    {
        private readonly BooksService _booksService;

        public BookApi(string apiKey)
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()

            });
        }
        public Tuple < int ? , List<BookModel>> Search(string query, int offset, int count)
        {
            var listQuery = _booksService.Volumes.List(query);
            listQuery.MaxResults = count;
            listQuery.StartIndex = offset;
            var res = listQuery.Execute();
            var books = res.Items.Select(b => new BookModel
            {
                Id = b.Id,
                Title = b.VolumeInfo.Title,
                Subtitle = b.VolumeInfo.Subtitle,
                Description = b.VolumeInfo.Description,
                PageCount = b.VolumeInfo.PageCount,
                ImgLinks = b.VolumeInfo.ImageLinks.ToString()
            }).ToList();
            return new Tuple<int?, List<BookModel>>(res.TotalItems, books);
        }
    }
}
