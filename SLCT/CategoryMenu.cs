using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace SLCT
{
    public partial class CategoryMenu : Form
    {
        public CategoryMenu()
        {
            InitializeComponent();
            comboStrategy.Items.Clear();

            comboStrategy.Items.Add("Simple Scoring");
            comboStrategy.Items.Add("Negative Scoring");
            comboStrategy.Items.Add("Timed Scoring");
            comboStrategy.SelectedIndex = 0;

        }

        private void buttonPR_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Programare", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonMA_Click(object sender, EventArgs e)
        {

            QuizForm quiz = new QuizForm("Matematica", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonIS_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Istorie", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonGE_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Geografie", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonFI_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Fizica", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private void buttonSP_Click(object sender, EventArgs e)
        {
            QuizForm quiz = new QuizForm("Sport", GetStrategy());

            quiz.StartPosition = FormStartPosition.Manual;
            quiz.Location = this.Location;
            quiz.Size = this.Size;
            quiz.WindowState = this.WindowState;

            quiz.Show();
            this.Hide();
        }

        private IScoringStrategy GetStrategy()
        {
            string selected = comboStrategy.SelectedItem.ToString();

            if (selected == "Negative Scoring")
                return new NegativeScoring();

            if (selected == "Timed Scoring")
                return new TimedScoring();

            return new SimpleScoring();
        }

        private void comboStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
