// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       QuestionManager.cs
// Autor:        Chira Ioana
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fișierul conține clasa de gestionare a întrebărilor, care se ocupă de încărcarea întrebărilor din fișierele JSON,
//               filtrarea acestora după categorie și oferirea unei liste de obiecte Question pentru categoria respectivă.
//               De asemenea, clasa oferă metode pentru a obține lista de categorii disponibile în întrebările încărcate.
//               În cazul unor probleme la încărcarea sau utilizarea întrebărilor, clasa aruncă excepții specifice pentru a oferi
//               feedback clar și util pentru depanare.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBManagement
{
    /// <summary>
    /// Clasa care se ocupa de incarcarea intrebarilor din fisierele JSON, filtrarea acestora dupa categorie si oferirea unei liste de obicete Question pentru categoria respectiva.
    /// </summary>
    public class QuestionManager
    {
        private List<Question> _questions;
        /// <summary>
        /// Constructor care incarca intrebarile din fisierul JSON specificat sau din Questions.json daca nu se specifica altceva. Daca fisierul nu exista sau nu poate fi incarcat, va arunca o exceptie.
        /// </summary>
        /// <param name="filePath">Numele fisierului JSON care contine intrebarile.</param>
        public QuestionManager(string filePath = "Questions.json")
        {
            //daca ni se ofera un sir gol
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Calea către fișier nu poate fi goală.", nameof(filePath));

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            _questions = new List<Question>();
            
            //incercam incarcarea intrebarilor prin LoadQuestions
            LoadQuestions(fullPath);
  
        }

        /// <summary>
        ///  Metoda prin care sunt incarcate intrebarile din fisierul JSON specificat. Daca fisierul nu exista sau nu poate fi incarcat, va arunca o exceptie.
        /// </summary>
        /// <param name="filePath">Calea către fișierul JSON care conține întrebările.</param>
        public void LoadQuestions(string filePath)
        {
            //verificam daca fisierul exista, daca nu, aruncam exceptie 
            if (!File.Exists(filePath))
                throw new QuestionsFileNotFoundException(filePath);


            string jsonString;

            //incercam citirea fisierului, daca nu reusim, aruncam exceptie
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new FileAccessException(filePath, ex);
            }
            catch (IOException ex)
            {
                throw new FileAccessException(filePath, ex);
            }

            if (string.IsNullOrWhiteSpace(jsonString))
                throw new EmptyQuestionsFileException(filePath);

            //incercam deserializarea, daca nu reusim, aruncam exceptie
            try
            {
                _questions = JsonSerializer.Deserialize<List<Question>>(jsonString)
                    ?? throw new EmptyQuestionsFileException(filePath);
            }
            catch (JsonException ex)
            {
                throw new InvalidQuestionsFormatException(filePath);
            }

            if (!_questions.Any())
                throw new EmptyQuestionsFileException(filePath);
        }

        /// <summary>
        /// Metoda care returneaza o lista de obiecte Question pentru categoria specificata. Daca categoria este nula sau goala, va arunca o exceptie. Daca nu exista intrebari pentru categoria respectiva, va returna o lista goala.
        /// </summary>
        /// <param name="category">Categoria pentru care se doresc intrebarile.</param>
        /// <returns>O lista de obiecte Question pentru categoria specificata.</returns>
        /// <exception cref="ArgumentException">Aruncata daca categoria este nula sau goala.</exception>
        public List<Question> GetQuestions(string category)
        {
            //verificam daca categoria este nula sau goala, daca da, aruncam exceptie
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Categoria nu poate fi goală.", nameof(category));

            //generam o lista de intrebari in ordine aleatoare pt categoria specificata
            Random rand = new Random();
            var result =  _questions.Where(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(q => rand.Next())
                .ToList();

            if (!result.Any())
                throw new NoCategoryFoundException(category);

            return result;
        }

        /// <summary>
        /// Metoda care returneaza o lista de categorii distincte disponibile in intrebarile incarcate. Daca nu exista intrebari incarcate, va arunca o exceptie.
        /// </summary>
        /// <returns>O lista de categorii distincte disponibile in intrebarile incarcate.</returns>
        /// <exception cref="InvalidOperationException">Aruncata atunci cand nu exista intrebari incarcate.</exception>
        public List<string> GetCategories()
        {
            //verificam daca avem intrebari incarcate, daca nu, aruncam exceptie
            if (_questions == null || !_questions.Any())
                throw new EmptyQuestionsFileException("fisier nerecunoscut");

            return _questions.Select(q => q.Category)
                .Distinct()
                .ToList();
        }
    }
}
