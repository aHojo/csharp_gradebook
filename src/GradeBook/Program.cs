using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Kairi's Gradebook");

            book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(99.5);

            Statistics stats = book.GetStatistics();
            Console.WriteLine($"The average grade is {stats.Average:N1}"); // 1 decimal places printed 
            Console.WriteLine($"The lowest grade is => {stats.Low}\nThe highest grade is {stats.High}");

        }
    }
}
