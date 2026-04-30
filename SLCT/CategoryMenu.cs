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
    public partial class CategoryMenu : Form
    {
        public CategoryMenu()
        {
            InitializeComponent();

        }

        private void buttonPR_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Programare").Show();
        }

        private void buttonMA_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Matematica").Show();
        }

        private void buttonIS_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Istorie").Show();
        }

        private void buttonGE_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Geografie").Show();
        }

        private void buttonFI_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Fizica").Show();
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            this.Hide();
            new QuizForm("Sport").Show();
        }
    }
}
