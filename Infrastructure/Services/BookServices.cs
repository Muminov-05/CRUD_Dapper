using Dapper;
using Domain.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookServices 
    {
        private string connect = "Host=localhost;Port=5432;Database=MGU; Username=postgres; Password=AMIRJON2005";


        public List<Books> GetBooks()
        {
            using var connected = new NpgsqlConnection(connect);
            return connected.Query<Books>("select * from  Books").ToList();
        }

        public void AddBook(Books book)
        {
            using var connected = new NpgsqlConnection(connect);
            connected.Execute(@"insert into Books(Title,Author,Isbn,Genre,Date_of_print,Dostup)
                                values(@Title,@Author,@Isbn,@Genre,@Date_of_print,@Dostup)", book);
            Console.WriteLine("Значение добавлены");
        }

        /*public List<Books> ReadBook()
        {
            using var connected = new NpgsqlConnection(connect);
            List<Books> books = connected.Query<Books>("SELECT * FROM Books").AsList();
            return books;
        }*/
        public List<Books> ReadBook()
        {
            using var connected = new NpgsqlConnection(connect);
            connected.Open();
            // Все имена столбцов совпадают с именами свойств — можно просто SELECT *
            var books = connected.Query<Books>("SELECT * FROM Books").ToList();
            return books;
        }

        public void UpdateBook(Books book)
        {
            using var connected = new NpgsqlConnection(connect);
            connected.Execute(@"Update Books set title=@title,Author=@author,Isbn=@Isbn,Genre=@Genre,Date_of_print=@Date_of_print,Dostup=@Dostup
                                where Id=@Id", book);
        }

        public void DeleteBook(int id)
        {
            using var connected = new NpgsqlConnection(connect);
            connected.Execute("delete from Books where Id=@Id ", new { Id = id });
            Console.WriteLine($"Книга с id = {id} удалена.");
        }

        public List<Books> SearchToAuthor(string author)
        {
            using var connected = new NpgsqlConnection(connect);
            return connected.Query<Books>("select * from Books where author=@author", new { Author = author }).ToList();
        }
    }
}
