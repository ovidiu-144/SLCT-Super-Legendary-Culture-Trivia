// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       MainMenu.cs
// Autor:        Alesia Lefter
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Materie:      Ingineria Programării
// Descriere:    Formularul principal al aplicației. Este primul
//               ecran văzut de utilizator și oferă opțiunile
//               de a începe jocul sau de a ieși din aplicație.



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
    /// Formularul principal (ecranul de start) al aplicației SLCT.
    /// Se deschide maximizat și fără bordură, ocupând tot ecranul.
    /// Oferă navigare către meniul de categorii sau închiderea aplicației.
    /// </summary>
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Inițializează formularul principal.
        /// Setează fereastra ca maximizată, fără bordură și cu
        /// poziție manuală pentru o experiență fullscreen.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized; //deschide fereastra full screen
            this.FormBorderStyle = FormBorderStyle.None;   
            this.StartPosition = FormStartPosition.Manual; 
        }

        /// <summary>
        /// Handler pentru butonul „Exit".
        /// Închide complet aplicația.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handler pentru butonul „Start Game".
        /// Deschide meniul de selectare a categoriei, transferând
        /// poziția, dimensiunea și starea ferestrei curente,
        /// apoi ascunde formularul principal.
        /// </summary>
        /// <param name="sender">Butonul care a declanșat evenimentul.</param>
        /// <param name="e">Datele evenimentului de click.</param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            CategoryMenu categoryMenu = new CategoryMenu();

            // transferă poziția și dimensiunea ferestrei curente
            categoryMenu.StartPosition = FormStartPosition.Manual;
            categoryMenu.Location = this.Location;
            categoryMenu.Size = this.Size;
            categoryMenu.WindowState = this.WindowState;

            categoryMenu.Show();
            this.Hide(); // ascunde MainMenu fără să închidă aplicația
        }
    }
}
