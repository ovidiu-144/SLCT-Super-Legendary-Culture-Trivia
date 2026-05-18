// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       QuizForm.cs
// Autor:        Alesia Lefter
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Formularul principal de desfășurare a quiz-ului.
//               Afișează întrebările și cele 4 variante de răspuns,
//               oferă feedback vizual (verde/roșu) la selecția
//               utilizatorului și navighează automat la ScoreForm
//               la finalizarea tuturor întrebărilor.


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
using DBManagement;

namespace SLCT
{
    /// <summary>
    /// Formularul de quiz. Gestionează afișarea întrebărilor,
    /// colectarea răspunsurilor utilizatorului, feedback-ul vizual
    /// și tranziția către ecranul de scor final.
    /// Folosește QuizEngine din layer-ul Logic pentru toată logica de joc.
    /// </summary>
    public partial class QuizForm : Form
    {
        private QuizEngine _quizEngine;
        private string _category;
        private IScoringStrategy _strategy;

        /// <summary>
        /// Inițializează formularul de quiz cu categoria și strategia specificate.
        /// Configurează QuizEngine, verifică existența întrebărilor pentru
        /// categoria aleasă și afișează prima întrebare.
        /// În caz de eroare (categorie fără întrebări sau problemă la încărcare),
        /// afișează un mesaj de eroare și închide formularul.
        /// </summary>
        /// <param name="categorie">Categoria de întrebări selectată.</param>
        /// <param name="strategy">Strategia de punctaj aplicată în sesiune.</param>
        public QuizForm(string categorie, IScoringStrategy strategy)
        {
            InitializeComponent();

            _strategy = strategy;
            _category = categorie;

            richTextBoxQuestion.ReadOnly = true; // utilizatorul nu poate edita textul întrebării
            richTextBoxScore.ReadOnly = true; // utilizatorul nu poate edita scorul afișat

            _category = categorie;
            this.Text = "SLCT — " + categorie;


            try
            {
                string strategyName = strategy.GetType().Name.Replace("Scoring", "");
                _quizEngine = new QuizEngine(strategyName);
                _quizEngine.StartQuiz(categorie);
                _quizEngine.ShuffleOptions(); //afisarea raspunsurilor sa fie in ordine aleatoare

                if (_quizEngine.IsFinished()) // dacă nu există întrebări, închidem formularul
                {
                    MessageBox.Show("Nu există întrebări pentru categoria selectată.",
                        "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            catch (DBManagement.NoCategoryFoundException ex)
            {
                // categoria nu există în fișierul JSON
                MessageBox.Show(ex.Message, "Categorie inexistentă",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            catch (DBManagement.QuestionsFileNotFoundException ex)
            {
                // fișierul Questions.json lipsește sau nu poate fi găsit
                MessageBox.Show(ex.Message, "Fișier lipsă",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                // orice altă eroare neașteptată
                MessageBox.Show($"Eroare la încărcarea întrebărilor: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            AfiseazaIntrebare();
        }

        /// <summary>
        /// Actualizează interfața cu datele întrebării curente din QuizEngine.
        /// Dacă quiz-ul s-a terminat, deschide ScoreForm și ascunde QuizForm.
        /// Altfel, populează textul întrebării, variantele de răspuns și
        /// informațiile de progres, apoi reactivează butoanele de răspuns.
        /// </summary>
        private void AfiseazaIntrebare()
        {
            if (_quizEngine.IsFinished())
            {
                ScoreForm scoreForm = new ScoreForm(_quizEngine.Score, _quizEngine.TotalQuestions);

                // transferă dimensiunea și poziția ferestrei curente
                scoreForm.StartPosition = FormStartPosition.Manual; //preia dimensiunea paginii anterioare
                scoreForm.Location = this.Location;
                scoreForm.Size = this.Size;
                scoreForm.WindowState = this.WindowState;

                scoreForm.Show();
                this.Hide();
                return;
            }

            DBManagement.Question q = _quizEngine.CurrentQuestion;


            // afișăm progresul: categorie, scor curent, numărul întrebării
            richTextBoxQuestion.Text = q.Text;
            richTextBoxScore.Text =
                $"Categorie: {_category}\nScor: {_quizEngine.Score}\nÎntrebarea {_quizEngine.CurrentIndex + 1} / {_quizEngine.TotalQuestions}";

            // populăm butoanele cu variantele de răspuns
            buttonA.Text = q.Options[0];
            buttonB.Text = q.Options[1];
            buttonC.Text = q.Options[2];
            buttonD.Text = q.Options[3];

            buttonA.Focus(); // focus pe primul buton pentru navigare cu tastatura

            // reactivăm butoanele după feedback-ul vizual de la întrebarea anterioară
            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;
        }

        /// <summary>
        /// Procesează răspunsul selectat de utilizator în mod asincron.
        /// Dezactivează butoanele pentru a preveni răspunsuri multiple,
        /// colorează în verde butonul corect și în roșu cel greșit (dacă e cazul),
        /// așteaptă 800ms pentru feedback vizual, resetează culorile,
        /// avansează la întrebarea următoare și apelează AfiseazaIntrebare().
        /// </summary>
        /// <param name="index">Indexul variantei alese (0=A, 1=B, 2=C, 3=D).</param>
        private async void VerificaRaspuns(int index)
        {
            // dezactivăm butoanele pentru a preveni click-uri multiple
            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;

            bool isCorrect = _quizEngine.SubmitAnswer(index);

            if (isCorrect)
            {
                // răspuns corect — colorăm butonul apăsat în verde
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.LightGreen;
            }
            else
            {
                // răspuns greșit — roșu pe cel apăsat, verde pe cel corect
                ((Button)Controls["button" + "ABCD"[index]]).BackColor = Color.IndianRed;

                int correct = _quizEngine.CurrentQuestion.CorrectAnswer;
                ((Button)Controls["button" + "ABCD"[correct]]).BackColor = Color.LightGreen;
            }

            await Task.Delay(800); // pauză de 800ms pentru ca utilizatorul să vadă feedback-ul
            Color culoareaInitiala = Color.Navy;

            buttonA.BackColor = culoareaInitiala;
            buttonB.BackColor = culoareaInitiala;
            buttonC.BackColor = culoareaInitiala;
            buttonD.BackColor = culoareaInitiala;

            _quizEngine.NextQuestion();
            AfiseazaIntrebare();
        }

        /// <summary>
        /// Handler pentru butonul variantei A.
        /// Apelează VerificaRaspuns cu indexul 0.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonA_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(0);
        }

        /// <summary>
        /// Handler pentru butonul variantei B.
        /// Apelează VerificaRaspuns cu indexul 1.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonB_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(1);
        }

        /// <summary>
        /// Handler pentru butonul variantei C.
        /// Apelează VerificaRaspuns cu indexul 2.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(2);
        }

        /// <summary>
        /// Handler pentru butonul variantei D.
        /// Apelează VerificaRaspuns cu indexul 3.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonD_Click(object sender, EventArgs e)
        {
            VerificaRaspuns(3);
        }

        /// <summary>
        /// Handler pentru evenimentul de modificare a textului din richTextBoxQuestion.
        /// Rezervat pentru logică viitoare
        /// </summary>
        /// <param name="sender">RichTextBox-ul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de modificare.</param>
        private void richTextBoxQuestion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
