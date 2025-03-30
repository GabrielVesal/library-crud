using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using System.Text.Json;

namespace LogicLibrary.Services
{
    public class BookManager
    {
        private List<Book> _books = new List<Book>();

        private readonly string _filepath = "Books.json";

        public BookManager()
        {
            GetBooks();
        }

        public void GetBooks()
        {
            if (File.Exists(_filepath))
            {
                var json = File.ReadAllText(_filepath);
                var options = new JsonSerializerOptions
                {
                    Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                };
                _books = JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
            }
        }



        public List<Book> ListBooks()
        {
            return _books;
        }

        public Book GetBook(string id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void SavedBooks()
        {
            var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filepath, json);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            SavedBooks();
        }

        public void UpdateBook(string id, Book book)
        {
            var index = _books.FindIndex(b => b.Id == id);

            if (index >= 0)
            {
                _books[index] = book;
                SavedBooks();
            }
        }

        public void RemoveBook(string id)
        {
            _books.RemoveAll(b => b.Id == id);
            SavedBooks();
        }
    }


}
