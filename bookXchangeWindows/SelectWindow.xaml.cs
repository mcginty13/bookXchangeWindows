using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bookXchangeWindows
{
    /// <summary>
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        List<BookModel> booklist;
        public SelectWindow(List<BookModel> pBookList)
        {
            InitializeComponent();
            lvBookResults.ItemsSource = pBookList;
            booklist = pBookList;
        }

        public BookModel activeBM { get; set; }
        public ImageSource GetImage(String pUrl)
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri(pUrl, UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();

            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }

            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);

            image.StreamSource = memoryStream;
            image.EndInit();

            return image;
        }

        public void UpdateContent(BookModel pBook)
        {
            title_TextBlock.Text = pBook.Title;
            subtitle_Textblock.Text = pBook.Subtitle;
            authors_Textblock.Text = pBook.Author;
            descr_Textblock.Text = pBook.Description;
            pagecount_Textblock.Text = pBook.PageCount.ToString();
            categories_Textblock.Text = pBook.Categories[0];
            myImage.Source = GetImage(pBook.ImgLinks);
        }
        private void select_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void lvBookResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedbookIndex = lvBookResults.SelectedIndex;
            activeBM = booklist[selectedbookIndex];
            UpdateContent(activeBM);
        }
        public BookModel ShowBookModelDialog()
{
    
    this.ShowDialog();
   
    return activeBM;
}

    }
}
