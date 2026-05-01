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

        private string _category;
        private int _currentIndex = 0;
        private int _score = 0;

        private List<(string text, string[] options, int correct)> _questions;

        public QuizForm(string categorie)
        {
            InitializeComponent();

            richTextBoxQuestion.ReadOnly = true;
            richTextBoxScore.ReadOnly = true;

            _category = categorie;
            this.Text = "SLCT — " + categorie;

            IncarcaIntrebari();
            AfiseazaIntrebare();
        }

        private void IncarcaIntrebari()
        {
            if (_category == "Programare")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("Câte biti are un byte?", new[] {"4", "8", "16", "32"}, 1),
                    ("Ce înseamnă CPU?", new[] {"Central Processing Unit", "Computer Power Unit", "Core Program Utility", "Central Program Upload"}, 0),
                };
            }
            else if (_category == "Matematica")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("Cât face 7 x 8?", new[] {"54", "56", "58", "64"}, 1),
                    ("Rădăcina pătrată din 81?", new[] {"7", "8", "9", "10"}, 2),
                };
            }
            else if (_category == "Istorie")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("În ce an a avut loc Marea Unire?", new[] {"1916", "1918", "1920", "1930"}, 1),
                };
            }
            else if (_category == "Geografie")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("Care este capitala Franței?", new[] {"Berlin", "Madrid", "Paris", "Roma"}, 2),
                };
            }
            else if (_category == "Sport")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("Câți jucători are o echipă de fotbal pe teren?", new[] {"9", "10", "11", "12"}, 2),
                };
            }
            else if (_category == "Fizica")
            {
                _questions = new List<(string, string[], int)>
                {
                    ("Unitatea de măsură pentru forță este?", new[] {"Joule", "Newton", "Watt", "Pascal"}, 1),
                };
            }

            // Randomizare întrebări
            _questions = _questions.OrderBy(x => Guid.NewGuid()).ToList();
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

            richTextBoxQuestion.Text = q.text;
            richTextBoxScore.Text =
                $"Categorie: {_category}\nScor: {_score}\nÎntrebarea {_currentIndex + 1} / {_questions.Count}";

            buttonA.Text = q.options[0];
            buttonB.Text = q.options[1];
            buttonC.Text = q.options[2];
            buttonD.Text = q.options[3];

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

            if (index == _questions[_currentIndex].correct)
            {
                _score++;
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.LightGreen;
            }
            else
            {
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.IndianRed;

                int correct = _questions[_currentIndex].correct;
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
    }
}
