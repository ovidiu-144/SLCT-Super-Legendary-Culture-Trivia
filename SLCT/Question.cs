using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLCT
{
    public class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectAnswer { get; set; }
        public string Category { get; set; }
    }
}
