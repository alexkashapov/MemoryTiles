using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTiles
{
    public partial class Form2 : Form
    {
        DateTime time = DateTime.MinValue;
        Label firstClicked = null;
        Label secondClicked = null;
        GameController controller = new GameController();
        float height;
        float width=1/4F;
        public Form2(int row)
        {
            InitializeComponent();
            height = 1f / row;
            tableLayoutPanelConfigured(row);
            AssignIconsToSquares(controller.generate(row));
            timer2.Start();
        }

        private void updateTime(object state)
        {
            time.AddSeconds(1);    
        }

        private void tableLayoutPanelConfigured(int row)
        {
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowOnly;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = row;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel1.Controls.Container.Dock = DockStyle.Fill;

        }

        private void AssignIconsToSquares(string[,] field)
        {
            for(int i=0; i < field.GetLength(1);i++)
            {
                tableLayoutPanel1.Controls.Container.RowStyles.Add(new RowStyle(SizeType.Percent,height));
                for (int j = 0; j < field.GetLength(0); j++) {
                    Label label = new Label
                    {
                        Font = new Font("Webdings", 60, FontStyle.Bold),
                        Text = field[j,i],
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    label.Click += new EventHandler(label_Click);
                    label.ForeColor = tableLayoutPanel1.BackColor;
                    tableLayoutPanel1.Controls.Container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,width));
                    tableLayoutPanel1.Controls.Add(label,i,j);
                }
            }
            tableLayoutPanel1.Controls.Container.RowStyles.Add(new RowStyle(SizeType.Percent, height));
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                switch (controller.click(clickedLabel.Text)) {
                    case 0:
                        firstClicked = clickedLabel;
                        firstClicked.ForeColor = Color.Black;
                        break;
                    case 1:
                        secondClicked = clickedLabel;
                        secondClicked.ForeColor = Color.Black;
                        break;
                    case 2:
                        secondClicked = clickedLabel;
                        secondClicked.ForeColor = Color.Black;
                        timer1.Start();
                        break;
                }

                if (controller.checkForWinner())
                {
                    Win();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void Win()
        {
            timer2.Stop();
            try
            {
                StreamWriter sw = new StreamWriter(@"../../stata.txt",true);
                StringBuilder sb = new StringBuilder();
                sb.Append(Properties.Settings.Default.count++)
                .Append('\t')
                .Append(label17.Text);
                sw.WriteLine(sb.ToString());
                Properties.Settings.Default.Save();
                sw.Close();
            }
            catch
            {

            }
            controller.destroyGame();
            MessageBox.Show("You are win!", "Congratulations");
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.OpenForms[0].Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            label17.Text = time.ToString("mm:ss");
        }
    }
}
