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
    public partial class QuizForm : Form
    {
        private QuestionManager _questionManager = new QuestionManager();
        private string _category;
        private int _currentIndex = 0;
        private int _score = 0;

        private List<Question> _questions;

        public QuizForm(string categorie)
        {
            InitializeComponent();

            richTextBoxQuestion.ReadOnly = true;
            richTextBoxScore.ReadOnly = true;

            _category = categorie;
            this.Text = "SLCT — " + categorie;

            try
            {
                _questionManager.LoadQuestions("Questions.json");
                _questions = _questionManager.GetQuestions(categorie);

                if (_questions == null || _questions.Count == 0)
                {
                    MessageBox.Show("Nu există întrebări pentru categoria selectată.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea întrebărilor: {ex.Message}" , "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            AfiseazaIntrebare();
        }

        private void AfiseazaIntrebare()
        {
            if (_currentIndex >= _questions.Count)
            {
                ScoreForm scoreForm = new ScoreForm(_score, _questions.Count);

                scoreForm.StartPosition = FormStartPosition.Manual;
                scoreForm.Location = this.Location;
                scoreForm.Size = this.Size;
                scoreForm.WindowState = this.WindowState;

                scoreForm.Show();
                this.Hide();
                return;
            }

            var q = _questions[_currentIndex];

            richTextBoxQuestion.Text = q.Text;
            richTextBoxScore.Text =
                $"Categorie: {_category}\nScor: {_score}\nÎntrebarea {_currentIndex + 1} / {_questions.Count}";

            buttonA.Text = q.Options[0];
            buttonB.Text = q.Options[1];
            buttonC.Text = q.Options[2];
            buttonD.Text = q.Options[3];

            buttonA.Focus();

            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;
        }

        private async void VerificaRaspuns(int index)
        {
            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;

            if (index == _questions[_currentIndex].CorrectAnswer)
            {
                _score++;
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.LightGreen;
            }
            else
            {
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.IndianRed;

                int correct = _questions[_currentIndex].CorrectAnswer;
                ((Button)Controls["button" + "ABCD"[correct]]).BackColor = Color.LightGreen;
            }

            await Task.Delay(800);
            Color culoareaInitiala = Color.Navy;

            buttonA.BackColor = culoareaInitiala;
            buttonB.BackColor = culoareaInitiala;
            buttonC.BackColor = culoareaInitiala;
            buttonD.BackColor = culoareaInitiala;

            _currentIndex++;
            AfiseazaIntrebare();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(0);
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(1);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(2);
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(3);
        }

        private void richTextBoxQuestion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
