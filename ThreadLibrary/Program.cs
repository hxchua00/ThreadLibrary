using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread entrance = new Thread(()=> { LibEntry(); });
            //entrance.IsBackground = true;
            entrance.Start();
        }

        public static void LibEntry()
        {
            Library lib = new Library();

            Console.WriteLine("Enter student ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool verification = lib.VerifyStudent(ID);
            Thread InLib = new Thread(() => LibMenu(ID));
            if (verification == true)
            {
                Console.WriteLine("Welcome to the library!");
                lib.PrintStudentDetails(ID);
                if (!InLib.IsAlive)
                    InLib.Start();
            }
            else
            {
                Console.WriteLine("Student ID not found, access denied!");
                Console.WriteLine();
                Console.ReadLine();
            }

        }

        public static void LibMenu(int ID)
        {
            Library lib = new Library();
            bool cont = true;
            while (cont)
            {
                Console.WriteLine("What do you wish to do at the Library?");
                Console.WriteLine();
                Console.WriteLine("1) Borrow book");
                Console.WriteLine("2) ReturnBook");
                Console.WriteLine("3) Nothing");
                Console.WriteLine();

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        lib.BorrowBook(ID);
                        break;
                    case 2:
                        lib.ReturnBook(ID);
                        break;
                    case 3:
                        Console.WriteLine("I hope you found what you need! Goodbye!");
                        Console.WriteLine();
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid procedure! Please behave in the Library!");
                        break;
                }
            }
        }
    }
}
