// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       ScoreForm.cs
// Autor:        Alesia Lefter
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Materie:      Ingineria Programării
// Descriere:    Formular de afișare a scorului final după
//               terminarea unui quiz. Permite utilizatorului
//               să revină la meniul de categorii sau să iasă
//               din aplicație.



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
    /// <summary>
    /// Formular care afișează rezultatul final al quiz-ului.
    /// Primește scorul și numărul total de întrebări,
    /// calculează punctajul și oferă opțiuni de navigare.
    /// </summary>
    public partial class ScoreForm : Form
    {
        /// <summary>
        /// Inițializează formularul cu rezultatele quiz-ului.
        /// Calculează punctajul (fiecare răspuns corect = 10 puncte)
        /// și afișează numărul de răspunsuri corecte din total.
        /// </summary>
        /// <param name="score">Numărul de răspunsuri corecte ale utilizatorului.</param>
        /// <param name="total">Numărul total de întrebări din quiz.</param>
        public ScoreForm(int score, int total)
        {
            InitializeComponent();
            labelScore.Text = $"Scorul tău: {score * 10} puncte";
            //labelDetalii.Text = $"{score} răspunsuri corecte din {total}";
        }

        /// <summary>
        /// Handler pentru butonul „Joacă din nou".
        /// Închide formularul curent și deschide meniul de categorii,
        /// păstrând poziția și dimensiunea ferestrei.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            CategoryMenu menu = new CategoryMenu();

            menu.StartPosition = FormStartPosition.Manual;
            menu.Location = this.Location;
            menu.Size = this.Size;
            menu.WindowState = this.WindowState;

            menu.Show();
            this.Hide();
        }

        /// <summary>
        /// Handler pentru butonul „Ieșire".
        /// Închide complet aplicația.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
