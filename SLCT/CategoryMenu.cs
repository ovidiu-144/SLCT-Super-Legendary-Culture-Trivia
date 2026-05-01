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
            QuizForm quiz = new QuizForm("Programare");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonMA_Click(object sender, EventArgs e)
        {

            QuizForm quiz = new QuizForm("Matematica");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonIS_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Istorie");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonGE_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Geografie");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonFI_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Fizica");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Sport");

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }
    }
}
