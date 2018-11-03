using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void click1(object sender, EventArgs e)
        {
            Hide();
            new Form2(3).Show();
        }

        private void click2(object sender, EventArgs e)
        {
            Hide();
            new Form2(4).Show();
        }

        private void click3(object sender, EventArgs e)
        {
            Hide();
            new Form2(5).Show();
        }

        private void statclick(object sender, EventArgs e)
        {
            Hide();
            new Statystics().Show();
        }
    }
}