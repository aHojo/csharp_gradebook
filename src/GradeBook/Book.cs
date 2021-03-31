using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0D;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (var grade in this.grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= this.grades.Count;

            return result;
        }

        public Book(string name)
        {
            this.grades = new List<double>();
            this.Name = name;

        }


    }
}