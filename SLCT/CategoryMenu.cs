// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       CategoryMenu.cs
// Autor:        Alesia [Numele tău de familie]
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Materie:      Ingineria Programării
// Descriere:    Formular pentru selectarea categoriei de întrebări
//               și a strategiei de punctaj. Utilizatorul alege
//               domeniul dorit (Programare, Matematică, Istorie etc.)
//               și tipul de scoring înainte de a începe quiz-ul.


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
    /// <summary>
    /// Formularul de selecție a categoriei și a strategiei de punctaj.
    /// Populează un ComboBox cu strategiile disponibile și lansează
    /// QuizForm cu categoria și strategia alese de utilizator.
    /// </summary>
    public partial class CategoryMenu : Form
    {
        /// <summary>
        /// Inițializează meniul de categorii și populează lista
        /// de strategii de punctaj disponibile (Simple, Negative, Timed).
        /// Strategia implicită selectată este Simple Scoring.
        /// </summary>
        public CategoryMenu()
        {
            InitializeComponent();
            comboStrategy.Items.Clear();

            comboStrategy.Items.Add("Simple Scoring");
            comboStrategy.Items.Add("Negative Scoring");
            comboStrategy.Items.Add("Timed Scoring");
            comboStrategy.SelectedIndex = 0;

        }

        /// <summary>
        /// Handler pentru butonul categoriei „Programare".
        /// Lansează QuizForm cu categoria „Programare" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Handler pentru butonul categoriei „Matematică".
        /// Lansează QuizForm cu categoria „Matematica" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Handler pentru butonul categoriei „Istorie".
        /// Lansează QuizForm cu categoria „Istorie" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Handler pentru butonul categoriei „Geografie".
        /// Lansează QuizForm cu categoria „Geografie" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Handler pentru butonul categoriei „Fizică".
        /// Lansează QuizForm cu categoria „Fizica" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Handler pentru butonul categoriei „Sport".
        /// Lansează QuizForm cu categoria „Sport" și strategia selectată.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
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

        /// <summary>
        /// Returnează instanța strategiei de punctaj corespunzătoare
        /// opțiunii selectate în ComboBox.
        /// Implicit returnează SimpleScoring dacă selecția nu este recunoscută.
        /// </summary>
        /// <returns>O instanță a interfeței IScoringStrategy.</returns>
        private IScoringStrategy GetStrategy()
        {
            string selected = comboStrategy.SelectedItem.ToString();

            if (selected == "Negative Scoring")
                return new NegativeScoring();

            if (selected == "Timed Scoring")
                return new TimedScoring();

            return new SimpleScoring();
        }

        /// <summary>
        /// Handler pentru evenimentul de schimbare a selecției din ComboBox.
        /// Rezervat pentru logică viitoare la schimbarea strategiei.
        /// </summary>
        /// <param name="sender">ComboBox-ul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de schimbare a selecției.</param>
        private void comboStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {}
    }
}
