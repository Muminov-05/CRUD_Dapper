using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Books
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Isbn { get; set; }
        public string Genre { get; set; }
        public DateTime Date_of_print { get; set; }
        public bool Dostup { get; set; }
        public Books() { }
        public Books(string title, string author, double isbn, string genre, DateTime date_of_Print , bool dostup)
        {
            Title = title; Author = author; Isbn = isbn; Genre = genre; Date_of_print = date_of_Print; Dostup = dostup;
        }
        public Books(int id, string title, string author, double isbn, string genre, DateTime date_of_Print, bool dostup)
        {
            Id = id;  Title = title; Author = author; Isbn = isbn; Genre = genre; Date_of_print = date_of_Print; Dostup = dostup;
        }
    }
}
