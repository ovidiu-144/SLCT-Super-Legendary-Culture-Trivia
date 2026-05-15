// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       Question.cs
// Autor:        Chira Ioana
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fișierul conține clasa care reprezintă o întrebare de tip quiz, textul întrebării,
//               opțiunile de răspuns, răspunsul corect și categoria din care face parte.
//               Această clasă este utilizată pentru a structura datele întrebărilor încărcate din
//               fișierele JSON și pentru a facilita manipularea acestora în cadrul aplicației de trivia.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManagement
{
    /// <summary>
    /// Clasă care reprezintă o întrebare de tip quiz, cu textul întrebării, opțiunile de răspuns, răspunsul corect și categoria din care face parte.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Intrebarea propriu-zisă, care va fi afișată utilizatorului. 
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Optiunile de răspuns pentru întrebarea respectivă, care vor fi afișate utilizatorului. Fiecare opțiune va fi o propoziție sau un cuvânt care poate fi selectat ca răspuns corect.
        /// </summary>
        public string[] Options { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Indexul opțiunii corecte în array-ul Options.
        /// </summary>
        public int CorrectAnswer { get; set; }
        /// <summary>
        /// Categoria din care face parte întrebarea, care poate fi utilizată pentru a organiza întrebările în funcție de subiect sau tematică. 
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
