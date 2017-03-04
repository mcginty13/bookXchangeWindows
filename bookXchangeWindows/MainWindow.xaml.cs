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
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace bookXchangeWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Book selectedBook;
        User activeUser = new User("1234", "Dan", "test@test.com", "compSci", 1);
        public MainWindow()
        {
            InitializeComponent();

        }


        public Tuple<int?, List<BookModel>> Search(string searchString)
        {

            BookApi bapi = new BookApi("AIzaSyADotKuKC73tBgI4hUZkBIcO_EzB5H55DI");
            Tuple<int?, List<BookModel>> resultsTuple = bapi.Search(searchString, 0, 1);
            return resultsTuple;

        }

        public void UpdateLabels()
        {
            bookName_Text.Text = selectedBook.GetTitle();
            ISBN_Text.Text = selectedBook.GetISBN();
            author_Text.Text = selectedBook.GetAuthor();
        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            BookModel returnedBookModel;
            try
            {
                var results = Search(search_TextBox.Text);
                if (results.Item1 == 0)
                {
                    MessageBox.Show("No Books Found");
                }
                else
                {
                    SelectWindow sw = new SelectWindow(results.Item2);
                    returnedBookModel = sw.ShowBookModelDialog();
                    selectedBook = new Book(returnedBookModel);
                    UpdateLabels();
                }
            }
            catch
            {
                MessageBox.Show("oops");
            }

        }

        private void CreateNewListing(Book pBook)
        {
            int price;
            bool priceSuccess;
            try
            {
                price = Convert.ToInt16(price_TextBox.Text);
                priceSuccess = true;
            }
            catch
            {
                MessageBox.Show("Please enter a valid price");
                price = 0;
                priceSuccess = false;
            }
            if (priceSuccess)
            {
                Listing listing = new Listing(activeUser, pBook, true, price);
                bool sendSuccess = SerializeAndSend(listing);
                if (sendSuccess)
                {
                    MessageBox.Show("listing created successfully");
                }
                else
                {
                    MessageBox.Show("Listing failed.");
                }
            }
        }

        private bool SerializeAndSend(Listing pListing)
        {
            try
            {
                Int32 port = 42004;
                string ipAdd = "127.0.0.1";

                TcpClient client = new TcpClient(ipAdd, port);
                XmlSerializer serializer = new XmlSerializer(typeof(Listing));
                
                NetworkStream stream = client.GetStream();

                serializer.Serialize(stream, pListing);
                stream.Flush();
                return true;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException: {0}", Convert.ToString(e));
                return false;
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: {0}", Convert.ToString(e));
                return false;
            }



        
        }

        private void sell_button_Click(object sender, RoutedEventArgs e)
        {
            CreateNewListing(selectedBook);
        }
    }
}
