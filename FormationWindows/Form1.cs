using FormationEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormationWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookModel bm = new BookModel { Book = new Book(), Id = Int32.Parse(TB_Id.Text) };

            TB_Title.Text = bm.Display();
            TB_Price.Text = bm.Price();
        }
    }
}
