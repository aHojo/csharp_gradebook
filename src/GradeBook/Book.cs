using System;
using System.Collections.Generic;

namespace GradeBook
{

    // defining an event, first need a delagate. 
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book
    {
        public event GradeAddedDelegate GradeAdded;
        private List<double> grades;

        /* Properties Below */
        /* OLD WAY
        private string name;
        public String Name
        {
            get
            {
                return name; // this is the private field
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value; // this variable is implicit, and given to you. 
                }
            }
        }
        */
        /* New Way - Auto Property. */
        public String Name
        {
            get;
            //private set;
            set;
        }

        // readonly String category; // can only change in the field or constructor. 
        public const String CATEGORY = "Science"; // with public here, others can now read it. 
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs()); // this object/class is the sender
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        // Overloaded Methods. 
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
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

            switch (result.Average)
            {
                case var d when d >= 90.0: // d gets assigned the value of result.Average. 
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public Book(string name)
        {
            this.grades = new List<double>();
            this.Name = name;

        }

        public List<double> GetGrades()
        {
            return this.grades;
        }

        // EVENT

    }
}