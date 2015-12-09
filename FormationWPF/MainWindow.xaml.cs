using FormationEF;
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

namespace FormationWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BookRepository br = new BookRepository { Entities = new FormationEFEntities() };

            BookModel bm = new BookModel { Book = new Book(), Id = Int32.Parse(TB_Id.Text) };

            TB_Title.Text = bm.Display();
            TB_Price.Text = bm.Price();
        }
        
        private void TB_Id_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TB_Id.Clear();
        }

        private void TB_Id_MouseEnter(object sender, MouseEventArgs e)
        {
            TB_Id.Clear();
        }
    }
}
