using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bookXchangeWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
           
        }

        public void Search()
        {
            string searchString = search_TextBox.Text;
            BookApi bapi = new BookApi("AIzaSyADotKuKC73tBgI4hUZkBIcO_EzB5H55DI");
            var resultsTuple = bapi.Search(searchString, 0, 1);
            List<BookModel> resultList = resultsTuple.Item2;
            Book book = new Book(resultList[0]);

            Title_textblock.Text = book.GetTitle();
            Subtitle_textblock.Text = book.GetSubtitle();
            Description_textblock.Text = book.GetDescription();
            pageCount_textblock.Text = book.GetPageCount().ToString();
          
        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
    }
}
