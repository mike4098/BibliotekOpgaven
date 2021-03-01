using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Makes a new list "Shopping Cart"
            List<Book> usersStack = new List<Book>();

           
            // Places a bunch of books on the counter
            Stack<string> usersbooks = new Stack<string>();
            Book logic = new Book();

            
            // Adds all books
            logic.addbooks();
            while (true)
            {
                Console.WriteLine("[1]find bøger [2]Lån bøger [3]Se resten af bøgerne ");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        logic.seeall();
                        Console.WriteLine("Skriv navnet på den bog du vil låne");
                        string inputname = Console.ReadLine();

                        //Asking the method to find the book you're searching for
                        Book LendBookToUser = logic.Lendbooks(inputname);
                        if (LendBookToUser != null)
                        {
                          
                            //adds to the shopping cart
                            usersStack.Add(LendBookToUser);
                        }
                        break;
                    case "2":

                        // Moves all the books from the shopping cart to the counter
                        movebook();
                        //  prints the name of the book for everytime there is an element in the queue
                        for (int i = 0; i <= usersbooks.Count; i++)
                        {
                            Console.WriteLine("Næste bog til at scanne hedder: " + usersbooks.Peek());

                         
                            // Here its scanned and removed from the queue
                            usersbooks.Pop(); 

                        }


                        break;
                    case "3":

                      
                        // Method to see the rest of the books
                        logic.seeall();
                        break;
                    default:
                        break;
                }



                Console.ReadLine();
            }
            // Method to move the books from the shopping cart to the count
            void movebook()
            {

                foreach (var item in usersStack)
                {
                    // Adds the name of the list to the queue
                    usersbooks.Push(item.name);
                }
                //Removes everything from the shopping cart
                usersStack.Clear();



            }
        }
    }
}