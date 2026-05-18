// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       Program.cs
// Autor:        Alesia Lefter
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Materie:      Ingineria Programării
// Descriere:    Punctul de intrare al aplicației SLCT.
//               Configurează setările inițiale pentru WinForms
//               și pornește aplicația prin afișarea formularului
//               principal (MainMenu).


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLCT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
