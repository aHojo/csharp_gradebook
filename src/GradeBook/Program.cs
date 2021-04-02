using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Kairi's Gradebook");

            // Subscribing to an event.
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            while (true)
            {
                Console.WriteLine("Input a grade. (q to quit)");
                // Get input from the user.
                var input = Console.ReadLine();

                // If q is entered, then break the loop.
                if (input.Equals("q"))
                {
                    break;
                }

                try
                {
                    // Parse the string into a double
                    double num = double.Parse(input);
                    book.AddGrade(num); // add the grade to the book.
                    // book.AddGrade('A'); // Sending the overloaded method. 
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message); // catching the exception will not crash our program. It will continue.
                                                      // throw; // Re throws the caught exception. 
                }
                finally
                {
                    Console.WriteLine("*****************");
                }

            }

            // book.AddGrade(89.1);
            // book.AddGrade(90.1);
            // book.AddGrade(99.5);

            Statistics stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}"); // 1 decimal places printed 
            Console.WriteLine($"The lowest grade is => {stats.Low}\nThe highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added from the event.");
        }
    }
}
