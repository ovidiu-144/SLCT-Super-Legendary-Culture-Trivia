using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SLCT
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
