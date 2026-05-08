using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DBManagement
{
    public class QuestionManager
    {
        private List<Question> _questions;

        public QuestionManager(string filePath = "Questions.json")
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            _questions = new List<Question>();
            LoadQuestions(fullPath); ;
        }
        public void LoadQuestions(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            _questions = JsonSerializer.Deserialize<List<Question>>(jsonString) ?? new List<Question>();

        }

        public List<Question> GetQuestions(string category)
        {
            Random rand = new Random();
            return _questions.Where(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(q => rand.Next())
                .ToList();
        }

        public List<string> GetCategories()
        {
            return _questions.Select(q => q.Category)
                .Distinct()
                .ToList();
        }
    }
}
