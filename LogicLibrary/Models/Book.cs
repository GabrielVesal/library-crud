using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models
{
    public class Book
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public enum CategoryType
        {
            Technology,
            Business,
            Science,
            Arts,
            Health
        }

        public enum LanguageType
        {
            English,
            Spanish,
            French,
            German,
            Portuguese
        }

        public CategoryType Category { get; set; }
        public LanguageType Language { get; set; }

        public string Url { get; set; }

    }
}
