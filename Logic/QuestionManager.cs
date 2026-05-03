using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic
{
    public class QuestionManager
    {
        private List<Question> _questions;

        public void LoadQuestions(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            _questions = JsonSerializer.Deserialize<List<Question>>(jsonString);

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