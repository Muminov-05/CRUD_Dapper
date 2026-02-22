using Domain.Models;
using Infrastructure.Services;
using static System.Reflection.Metadata.BlobBuilder;


BookServices services = new BookServices();

while (true) {
    Console.WriteLine("\n======================= Menu =======================");
    Console.WriteLine("1.Добавить  2.Удалить  3.Показат всех книг  4.Изменить  5.Поиск   0.Выход");
    Console.Write(" Ваш выбор : ");
    int vubor = Convert.ToInt32(Console.ReadLine());
    switch(vubor)
    {
        case 1:
            {
                var book5 = new Books("title5", "author5", 35, "genre5", new DateTime(2025, 10, 12), false);
                services.AddBook(book5);
                break;
            }
        case 2:
            {
                Console.Write("Введите Id для удаления  : ");
                int id1 = Convert.ToInt32(Console.ReadLine());
                services.DeleteBook(id1);
                break;
            }
        case 3:
            {
                var listBook = services.ReadBook();
                Console.WriteLine("Список книг в базе данных:");

                Console.WriteLine(new string('-', 98));
                Console.WriteLine(
                    "| {0,-3} | {1,-20} | {2,-15} | {3,-10} | {4,-10} | {5,-12} | {6,-6} |",
                    "Id", "Название", "Автор", "ISBN", "Жанр", "Дата печати", "Доступ");
                Console.WriteLine(new string('-', 98));

                foreach (var book in listBook)
                {
                    Console.WriteLine(
                        "| {0,-3} | {1,-20} | {2,-15} | {3,-10} | {4,-10} | {5,-12:yyyy-MM-dd} | {6,-6} |",
                        book.Id,  book.Title,  book.Author,  book.Isbn,  book.Genre,  book.Date_of_print,  book.Dostup ? "True" : "False");
                }
                Console.WriteLine(new string('-', 98));
                break;
            }
        case 4:
            {
                Console.Write("Id = "); int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Title = "); string title = Console.ReadLine();
                Console.Write("Author = "); string author = Console.ReadLine();
                Console.Write("Isbn = "); double isbn = Convert.ToDouble(Console.ReadLine());
                Console.Write("Genre = "); string genre = Console.ReadLine();
                Console.Write("Date_of_print = ");  DateTime date_of_print = DateTime.Parse(Console.ReadLine());
                Console.Write("Dostup = "); bool dostup = Convert.ToBoolean(Console.ReadLine());
                var newBook = new Books(id,title, author, isbn, genre, date_of_print, dostup);
                services.UpdateBook(newBook);
                Console.WriteLine($"Книга c Id = {id} успешно обновлена.");
                break;
            }
        case 5:
            {
                Console.Write("Введите имя автора для поиска  : ");
                string author  = Console.ReadLine();
                var listBookByAuthor = services.SearchToAuthor(author);
                Console.WriteLine($"Список книг с автором {author}");
                Console.WriteLine(new string('-', 98));
                Console.WriteLine(
                    "| {0,-3} | {1,-20} | {2,-15} | {3,-10} | {4,-10} | {5,-12} | {6,-6} |",
                    "Id", "Название", "Автор", "ISBN", "Жанр", "Дата печати", "Доступ");
                Console.WriteLine(new string('-', 98));
                foreach (var book in listBookByAuthor)
                {
                    Console.WriteLine(
                        "| {0,-3} | {1,-20} | {2,-15} | {3,-10} | {4,-10} | {5,-12:yyyy-MM-dd} | {6,-6} |",
                        book.Id, book.Title, book.Author, book.Isbn, book.Genre, book.Date_of_print, book.Dostup ? "True" : "False");
                }
                Console.WriteLine(new string('-', 98));
                break;
            }
        case 0:
            return;
    }
}