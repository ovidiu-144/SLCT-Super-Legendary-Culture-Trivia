// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       DBManagementException.cs
// Autor:        Chira Ioana
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fisierul conține clasa de excepții pentru gestionarea bazei de date de întrebări,
//               definind erori specifice legate de fișierele de întrebări și categoriile acestora,
//               pentru a oferi feedback clar și util în cazul unor probleme la încărcarea sau
//               utilizarea întrebărilor în aplicație.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBManagement
{
    /// <summary>
    /// Clasa de bază pentru excepțiile legate de gestionarea bazei de date de întrebări.
    /// </summary>
    public class DBManagementException : Exception
    {
        /// <summary>
        /// Constructor care primește un mesaj de eroare și îl transmite clasei de bază Exception.
        /// </summary>
        /// <param name="message">mesaj de eroare</param>
        public DBManagementException(string message) : base(message) { }

        /// <summary>
        /// Constructor care primește un mesaj de eroare și o excepție interioară, și le transmite clasei de bază Exception.
        /// </summary>
        /// <param name="message">mesaj de eroare</param>
        /// <param name="inner">excepția interioară</param>
        public DBManagementException(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// Clasa de excepție care indică faptul că fișierul de întrebări specificat nu a fost găsit.
    /// </summary>
    public class QuestionsFileNotFoundException : DBManagementException
    {
        // calea fișierului care nu a fost găsit
        public string FilePath { get; }
        /// <summary>
        /// Constructor care primește calea fișierului care nu a fost găsit și construiește un mesaj de eroare specific pentru această situație. 
        /// Mesajul indică faptul că fișierul respectiv nu a fost găsit, oferind astfel informații utile pentru depanare. 
        /// </summary>
        /// <param name="filePath">calea fișierului care nu a fost găsit</param>
        public QuestionsFileNotFoundException(string filePath)
            : base($"Fisierul '{filePath}' nu a fost gasit.")
        {
            FilePath = filePath;
        }
    }

    /// <summary>
    /// Clasa de excepție care indică faptul că fișierul de întrebări specificat nu are un format JSON valid.
    /// </summary>
    public class InvalidQuestionsFormatException : DBManagementException
    {
        // calea fișierului care are un format JSON invalid
        public string FilePath { get; }
        /// <summary>
        /// Constructor care primește calea fișierului care are un format JSON invalid și construiește un mesaj de eroare specific pentru această situație.
        /// </summary>
        /// <param name="filePath">calea fișierului care are un format JSON invalid</param>
        public InvalidQuestionsFormatException(string filePath)
            : base($"Fisierul '{filePath}' nu are un format JSON valid.")
        {
            FilePath = filePath;
        }
    }

    /// <summary>
    /// Clasa de excepție care indică faptul că fișierul de întrebări specificat nu conține nicio întrebare.
    /// </summary>
    public class EmptyQuestionsFileException : DBManagementException
    {
        // calea fișierului care nu conține nicio întrebare
        public string FilePath { get; }
        /// <summary>
        /// Constructor care primește calea fișierului care nu conține nicio întrebare și construiește un mesaj de eroare specific pentru această situație.
        /// </summary>
        /// <param name="filePath">calea fișierului care nu conține nicio întrebare</param>
        public EmptyQuestionsFileException(string filePath)
            : base($"Fisierul '{filePath}' nu contine nicio intrebare.")
        {
            FilePath = filePath;
        }
    }

    /// <summary>
    /// Clasa de excepție care indică faptul că fișierul de întrebări specificat nu poate fi accesat din cauza unei erori de I/O sau a unor permisiuni insuficiente.
    /// </summary>
    public class FileAccessException : DBManagementException
    {
        // calea fișierului care nu poate fi accesat
        public string FilePath { get; }
        /// <summary>
        /// Constructor care primește calea fișierului care nu poate fi accesat și excepția interioară, 
        /// și construiește un mesaj de eroare specific pentru această situație.
        /// </summary>
        /// <param name="filePath">calea fișierului care nu poate fi accesat</param>
        /// <param name="inner">excepția interioară</param>
        public FileAccessException(string filePath, Exception inner)
            : base($"Nu se poate accesa fisierul '{filePath}': {inner.Message}", inner)
        {
            FilePath = filePath;
        }
    }
    /// <summary>
    /// Clasa de excepție care indică faptul că nu există întrebări pentru categoria specificată în fișierul de întrebări.
    /// </summary>
    public class NoCategoryFoundException : DBManagementException
    {
        // categoria pentru care nu există întrebări
        public string Category { get; }
        /// <summary>
        /// Constructor care primește categoria pentru care nu există întrebări și construiește un mesaj de eroare specific pentru această situație.
        /// </summary>
        /// <param name="category">categoria pentru care nu există întrebări</param>
        public NoCategoryFoundException(string category)
            : base($"Nu exista intrebari pentru categoria '{category}'.")
        {
            Category = category;
        }
    }
}
