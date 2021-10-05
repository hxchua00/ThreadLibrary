using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLibrary
{
    class Student
    {
        public int studentID;
        public string studentName;
        public bool book;

        public Student(int studentID, string studentName, bool book)
        {
            this.studentID = studentID;
            this.studentName = studentName;
            this.book = book;
        }
    }
    class Library
    {
        static List<Student> Classroom = new List<Student>();
        bool IssuedBook = false;

        static Library()
        {
            Classroom.Add(new Student(1, "John", false));
            Classroom.Add(new Student(2, "Mary", false));
            Classroom.Add(new Student(3, "Owen", false));
            Classroom.Add(new Student(4, "Harry", false));
            Classroom.Add(new Student(5, "Ronald", false));
            Classroom.Add(new Student(6, "Tatsuya", false));
            Classroom.Add(new Student(7, "Kaguya", false));
            Classroom.Add(new Student(8, "Moris", false));
            Classroom.Add(new Student(9, "Eldo", false));
            Classroom.Add(new Student(10, "Freya", false));
        }

        public bool VerifyStudent(int ID)
        {
            foreach(Student s in Classroom)
            {
                if(s.studentID == ID)
                {
                   
                    return true;
                }
            }
            return false;
        }

        public bool IsBookIssued()
        {
            if (!IssuedBook)
            {
                return true;
            }
            return false;
        }

        public void BorrowBook(int ID)
        {
            bool checkbook = IsBookIssued();
            if(checkbook == false)
            {
                foreach (Student s in Classroom)
                {
                    if(s.studentID == ID)
                    {
                        if(s.book == false)
                        {
                            s.book = true;
                        }
                        else
                        {
                            Console.WriteLine("There's some trouble, you cannot borrow the book now. Sorry!");
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                Console.WriteLine("The book has been borrowed by: ");
                PrintStudentDetails(ID);
                IssuedBook = true;
            }
            else
            {
                Console.WriteLine("Sorry! It seems someone else has already borrowed the book!");
                Console.WriteLine();
            }
        }

        public void ReturnBook(int ID)
        {
            if (IsBookIssued() == true)
            {
                foreach (Student s in Classroom)
                {
                    if (s.studentID == ID)
                    {
                        if(s.book == true)
                        {
                            s.book = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("Is there a mistake? You don't have any book to return!");
                            Console.WriteLine();
                            break;
                        }
                    }
                }
                Console.WriteLine("Book is returned! Thank you!");
                Console.WriteLine();
                IssuedBook = false;
            }
            else
            {
                Console.WriteLine("Sorry! It seems someone else has already borrowed the book!");
                Console.WriteLine();
            }
        }


        public void PrintStudentDetails(int ID)
        {
            foreach(Student s in Classroom)
            {
                if(s.studentID == ID)
                {
                    Console.WriteLine("Student ID: {0}",s.studentID);
                    Console.WriteLine("Student name: {0}",s.studentName);
                    Console.WriteLine();
                }
            }
        }
    }
}
