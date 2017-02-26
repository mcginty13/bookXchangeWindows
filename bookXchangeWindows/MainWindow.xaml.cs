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

        public Tuple<int?, List<BookModel>> Search(string searchString)
        {

            BookApi bapi = new BookApi("AIzaSyADotKuKC73tBgI4hUZkBIcO_EzB5H55DI");
            Tuple<int?, List<BookModel>> resultsTuple = bapi.Search(searchString, 0, 1);
            return resultsTuple;

        }

        private void search_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var results = Search(search_TextBox.Text);
                if (results.Item1 == 0)
                {
                    MessageBox.Show("No Books Found");
                }
                else
                {
                    Window sw = new SelectWindow(results.Item2);
                    sw.Show();
                }
            }
            catch
            {
                MessageBox.Show("oops");
            }

        }
    }
}
