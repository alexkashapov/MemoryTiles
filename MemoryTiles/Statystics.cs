using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTiles
{
    public partial class Statystics : Form
    {
        public Statystics()
        {
            InitializeComponent();
            richTextBox1.AppendText("#\tВремя\n");
            richTextBox1.AppendText(Properties.Resources.stata);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.OpenForms[0].Show();
        }
    }

}
