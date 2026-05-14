using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBManagement
{
    public class DBManagementException : Exception
    {
        public DBManagementException(string message) : base(message) { }
        public DBManagementException(string message, Exception inner) : base(message, inner) { }
    }

    public class QuestionsFileNotFoundException : DBManagementException
    {
        public string FilePath { get; }
        public QuestionsFileNotFoundException(string filePath)
            : base($"Fisierul '{filePath}' nu a fost gasit.")
        {
            FilePath = filePath;
        }
    }

    public class InvalidQuestionsFormatException : DBManagementException
    {
        public string FilePath { get; }
        public InvalidQuestionsFormatException(string filePath)
            : base($"Fisierul '{filePath}' nu are un format JSON valid.")
        {
            FilePath = filePath;
        }
    }

    public class EmptyQuestionsFileException : DBManagementException
    {
        public string FilePath { get; }
        public EmptyQuestionsFileException(string filePath)
            : base($"Fisierul '{filePath}' nu contine nicio intrebare.")
        {
            FilePath = filePath;
        }
    }

    public class FileAccessException : DBManagementException
    {
        public string FilePath { get; }
        public FileAccessException(string filePath, Exception inner)
            : base($"Nu se poate accesa fisierul '{filePath}': {inner.Message}", inner)
        {
            FilePath = filePath;
        }
    }

    public class NoCategoryFoundException : DBManagementException
    {
        public string Category { get; }
        public NoCategoryFoundException(string category)
            : base($"Nu exista intrebari pentru categoria '{category}'.")
        {
            Category = category;
        }
    }
}
