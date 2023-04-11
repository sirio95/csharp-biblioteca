using System;
using System.Linq;


internal class Program
{

    // classe biblioteca

    public class Library
    {


        List<User> Users = new List<User>();
        List<Loan> Loans = new List<Loan>();
        List<Book> Books = new List<Book>();
        List<DVD> Dvds = new List<DVD>();


        Book libro1 = new Book("012e45trf54", "Passages", 1932, "Essay", "F6", new Author("Walter", "Benjamin"), 1024);
        Book libro2 = new Book("97gt43e12r5", "Signore degli anelli", 1954, "Fantasy", "F3", new Author("J. R. R.", "Tolkien"), 1315);
        Book libro3 = new Book("gk865kjga12", "Going Public", 2011, "Essay", "E6", new Author("Boris", "Groyce"), 217);


        DVD dvd1 = new DVD("agfn956720fj", "Jaws", 1975, "Thriller", "T3", new Author("Peter", "Jackson"), 124);
        DVD dvd2 = new DVD("agfn956720fk", "Jaws 2", 1978, "Thriller", "T3", new Author("J.", "Szwarc"), 116);
        DVD dvd3 = new DVD("agfn956720fl", "Jaws 3-D", 1983, "Thriller", "T3", new Author("Joe", "Alves"), 98);


        public Library(List<User> users, List <Loan> loans, List<Book> books, List<DVD> dvds)
        {
            this.Users = users;
            this.Loans = loans;
            this.Books = books;
            this.Dvds = dvds;
        }
        public User UserRegs()
        {
            Console.WriteLine("Segui tutti gli step per registrarti");
            Console.WriteLine("inserisci il tuo nome");
            string name= Console.ReadLine();
            Console.WriteLine("inserisci il tuo cognome");
            string lastName= Console.ReadLine();
            Console.WriteLine("inserisci la tua e-mail");
            string eMail = Console.ReadLine();
            Console.WriteLine("Inserisci la tua password");
            string password = Console.ReadLine();
            Console.WriteLine("inserisci il tuo numero di telefono");
            string phoneNum = Console.ReadLine();

            User newUser = new User(name, lastName, eMail, password, phoneNum);
            this.Users.Add(newUser);
            return newUser;
        }
        public void RequestLoan() 
        {
            Console.WriteLine("Benvenuto nella nostra biblioteca, ove sono ammessi solo prestiti di 3 mesi");
            Console.WriteLine("Premi 1 per chiedere in prestito un libro e 2 per un dvd");
            int documentChoice;
            while(!int.TryParse(Console.ReadLine(), out documentChoice)) { Console.WriteLine("digita un vero numero"); }
            while(documentChoice != 1 && documentChoice != 2) { Console.WriteLine("il numero scelto non è valido"); }
            if(documentChoice == 1) 
            {
                Console.WriteLine("Ecco la lista dei libri. Digita il numero di quello che desideri chiedere in prestito");
                foreach(Book book in Books)
                {
                    Console.WriteLine($"- {Books.IndexOf(book)} - {book.Title} - {book.Author.Name} {book.Author.LastName}");
                    Console.WriteLine($"Codice Libro: {book.Code} - {book.Year} - {book.Genre} - {book.PageNum} pagine");
                }
                int bookNum;
                while (!int.TryParse(Console.ReadLine(), out bookNum)) { Console.WriteLine("digita un vero numero"); }
                while (bookNum > Books.Count() - 1) { Console.WriteLine("il numero scelto non corrisponde a nessun prodotto"); }

                User userLoan = UserRegs();
                string startDate= DateTime.Now.ToString("M/d/yyyy");
                string endDate= DateTime.Now.AddMonths(+ 3).ToString("M/d/yyyy");

                Loan newLoan = new Loan(userLoan, this.Books[bookNum], startDate, endDate);
                this.Loans.Add(newLoan);
                Console.WriteLine($"Complimenti. Il tuo prestito scadrà il {endDate}");
            }
            else
            {
                Console.WriteLine("Ecco la lista dei DVD. Digita il numero di quello che desideri chiedere in prestito");
                foreach(DVD dvd in Dvds)
                {
                    Console.WriteLine($" - {Dvds.IndexOf(dvd)} - {dvd.Title} - {dvd.Author.Name} {dvd.Author.LastName}");
                    Console.WriteLine($"Codice DVD: {dvd.Code} - {dvd.Year} - {dvd.Genre} - {dvd.Duration} minuti");
                }
                int dvdNum;
                while (!int.TryParse(Console.ReadLine(), out dvdNum)) { Console.WriteLine("digita un vero numero"); }
                while (dvdNum > Dvds.Count() - 1) { Console.WriteLine("il numero scelto non è valido"); }

                User userLoan = UserRegs();
                string startDate = DateTime.Now.ToString("M/d/yyyy");
                string endDate = DateTime.Now.AddMonths(+3).ToString("M/d/yyyy");

                Loan newLoan = new Loan(userLoan, this.Dvds[dvdNum], startDate, endDate);
                this.Loans.Add(newLoan);
                Console.WriteLine($"Complimenti. Il tuo prestito scadrà il {endDate}");
            }
            
            
        }

        // classi di entità
        public class User
        {
            private string _Name;
            public string Name { get; set; }

            private string _LastName;
            public string LastName { get; set; }

            private string _Email;
            public string Email { get; set; }

            private string _Password;
            public string Password
            {
                private get
                {
                    return _Password;
                }
                set
                {
                    this._Password = value;
                }
            }

            private string _Phone;
            public string Phone { get; set; }

            public User(string name, string lastName, string email, string password, string phone)
            {
                this.Name = name;
                this.LastName = lastName;
                this.Email = email;
                this.Password = password;
                this.Phone = phone;
            }
        }

        public class Loan
        {
            private User _User;
            public User User { get; set; }

            private Document _Document;
            public Document Document { get; set; }

            private string _StartDate;
            public string StartDate { get; set; }
            private string _EndDate;
            public string EndDate { get; set; }

            public Loan(User user, Document document, string startDate, string endDate)
            {
                this.User = user;
                this.Document = document;
                this.StartDate = startDate;
                this.EndDate = endDate;
            }
        }
        public class Author
        {
            private string _Name;
            public string Name { get; set; }
            private string _LastName;
            public string LastName { get; set; }

            public Author(string name, string lastName)
            {
                this.Name = name;
                this.LastName = lastName;
            }
        }

        public class Document
        {
            private string _Code;
            public string Code { get; set; }

            private string _Title;
            public string Title { get; set; }

            private int _Year;
            public int Year { get; set; }

            private string _Genre;
            public string Genre { get; set; }

            private string _Shelf;
            public string Shelf { get; set; }

            public Author Author { get; set; }


            public Document(string code, string title, int year, string genre, string shelf, Author author)
            {
                this.Code = code;
                this.Title = title;
                this.Year = year;
                this.Genre = genre;
                this.Shelf = shelf;
                this.Author = author;
            }
        }
        public class Book : Document
        {
            private int _PageNum;
            public int PageNum { get; set; }

            public Book(string code, string title, int year, string genre, string shelf, Author author, int pageNum) : base(code, title, year, genre, shelf, author)
            {
                this.PageNum = pageNum;
            }
        }
        public class DVD : Document
        {
            private int _Duration;
            public int Duration { get; set; }

            public DVD(string code, string title, int year, string genre, string shelf, Author author, int duration) : base(code, title, year, genre, shelf, author)
            {
                this.Duration = duration;
            }
        }

    }

        
        




    
}