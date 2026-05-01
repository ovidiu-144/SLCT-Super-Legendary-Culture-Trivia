using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLCT
{
    public partial class ScoreForm : Form
    {
        //de completat aici, trebuie sa calculeze scorul x din 100 pct
        public ScoreForm(int score, int total)
        {
            InitializeComponent();
            labelScore.Text = $"Scorul tău: {score * 100} puncte";
            labelDetalii.Text = $"{score} răspunsuri corecte din {total}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();

            menu.StartPosition = FormStartPosition.Manual;
            menu.Location = this.Location;
            menu.Size = this.Size;
            menu.WindowState = this.WindowState;

            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
