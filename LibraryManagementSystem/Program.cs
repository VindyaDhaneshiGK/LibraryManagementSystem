namespace LibraryManagementSystem
{
    using System;

    class Program
    {
        static void Main()
        {
            // Step 1: Create variables for up to 5 books
            string book1 = "";
            string book2 = "";
            string book3 = "";
            string book4 = "";
            string book5 = "";

            // Track borrowed books
            bool borrowed1 = false;
            bool borrowed2 = false;
            bool borrowed3 = false;
            bool borrowed4 = false;
            bool borrowed5 = false;

            int borrowedCount = 0;
            const int borrowLimit = 3;

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("Choose an action: add / remove / display / search / borrow / checkin / exit");
                string action = Console.ReadLine()?.ToLower();

                switch (action)
                {
                    case "add":
                        Console.Write("Enter book title to add: ");
                        string newBook = Console.ReadLine();

                        if (string.IsNullOrEmpty(book1)) book1 = newBook;
                        else if (string.IsNullOrEmpty(book2)) book2 = newBook;
                        else if (string.IsNullOrEmpty(book3)) book3 = newBook;
                        else if (string.IsNullOrEmpty(book4)) book4 = newBook;
                        else if (string.IsNullOrEmpty(book5)) book5 = newBook;
                        else
                            Console.WriteLine("Library is full. Cannot add more books.");
                        break;

                    case "remove":
                        Console.Write("Enter book title to remove: ");
                        string removeBook = Console.ReadLine();

                        if (book1 == removeBook) { book1 = ""; borrowed1 = false; }
                        else if (book2 == removeBook) { book2 = ""; borrowed2 = false; }
                        else if (book3 == removeBook) { book3 = ""; borrowed3 = false; }
                        else if (book4 == removeBook) { book4 = ""; borrowed4 = false; }
                        else if (book5 == removeBook) { book5 = ""; borrowed5 = false; }
                        else
                            Console.WriteLine("Book not found in the library.");
                        break;

                    case "display":
                        Console.WriteLine("\nBooks in the library:");
                        if (!string.IsNullOrEmpty(book1)) Console.WriteLine($"{book1} {(borrowed1 ? "(Borrowed)" : "")}");
                        if (!string.IsNullOrEmpty(book2)) Console.WriteLine($"{book2} {(borrowed2 ? "(Borrowed)" : "")}");
                        if (!string.IsNullOrEmpty(book3)) Console.WriteLine($"{book3} {(borrowed3 ? "(Borrowed)" : "")}");
                        if (!string.IsNullOrEmpty(book4)) Console.WriteLine($"{book4} {(borrowed4 ? "(Borrowed)" : "")}");
                        if (!string.IsNullOrEmpty(book5)) Console.WriteLine($"{book5} {(borrowed5 ? "(Borrowed)" : "")}");

                        if (string.IsNullOrEmpty(book1) && string.IsNullOrEmpty(book2) &&
                            string.IsNullOrEmpty(book3) && string.IsNullOrEmpty(book4) &&
                            string.IsNullOrEmpty(book5))
                        {
                            Console.WriteLine("No books available.");
                        }
                        break;

                    case "search":
                        Console.Write("Enter book title to search: ");
                        string searchBook = Console.ReadLine();

                        if (book1 == searchBook || book2 == searchBook || book3 == searchBook ||
                            book4 == searchBook || book5 == searchBook)
                        {
                            Console.WriteLine($"Book '{searchBook}' is available in the library.");
                        }
                        else
                        {
                            Console.WriteLine($"Book '{searchBook}' is not in the collection.");
                        }
                        break;

                    case "borrow":
                        if (borrowedCount >= borrowLimit)
                        {
                            Console.WriteLine("Borrow limit reached. You cannot borrow more than 3 books at a time.");
                            break;
                        }

                        Console.Write("Enter book title to borrow: ");
                        string borrowBook = Console.ReadLine();

                        if (book1 == borrowBook && !borrowed1) { borrowed1 = true; borrowedCount++; Console.WriteLine($"You borrowed '{book1}'."); }
                        else if (book2 == borrowBook && !borrowed2) { borrowed2 = true; borrowedCount++; Console.WriteLine($"You borrowed '{book2}'."); }
                        else if (book3 == borrowBook && !borrowed3) { borrowed3 = true; borrowedCount++; Console.WriteLine($"You borrowed '{book3}'."); }
                        else if (book4 == borrowBook && !borrowed4) { borrowed4 = true; borrowedCount++; Console.WriteLine($"You borrowed '{book4}'."); }
                        else if (book5 == borrowBook && !borrowed5) { borrowed5 = true; borrowedCount++; Console.WriteLine($"You borrowed '{book5}'."); }
                        else
                            Console.WriteLine("Book not found or already borrowed.");
                        break;

                    case "checkin":
                        Console.Write("Enter book title to check in: ");
                        string checkinBook = Console.ReadLine();

                        if (book1 == checkinBook && borrowed1) { borrowed1 = false; borrowedCount--; Console.WriteLine($"You checked in '{book1}'."); }
                        else if (book2 == checkinBook && borrowed2) { borrowed2 = false; borrowedCount--; Console.WriteLine($"You checked in '{book2}'."); }
                        else if (book3 == checkinBook && borrowed3) { borrowed3 = false; borrowedCount--; Console.WriteLine($"You checked in '{book3}'."); }
                        else if (book4 == checkinBook && borrowed4) { borrowed4 = false; borrowedCount--; Console.WriteLine($"You checked in '{book4}'."); }
                        else if (book5 == checkinBook && borrowed5) { borrowed5 = false; borrowedCount--; Console.WriteLine($"You checked in '{book5}'."); }
                        else
                            Console.WriteLine("Book not found or not currently borrowed.");
                        break;

                    case "exit":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid action. Please choose add / remove / display / search / borrow / checkin / exit.");
                        break;
                }
            }
        }
    }
}
