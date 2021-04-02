using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    // defining an event, first need a delagate. 
    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public String Name { get; set; }

    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
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
        // public String Name
        // {
        //     get;
        //     //private set;
        //     set;
        // }

        // readonly String category; // can only change in the field or constructor. 
        public const String CATEGORY = "Science"; // with public here, others can now read it. 
        public override void AddGrade(double grade)
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
        public override Statistics GetStatistics()
        {
            var result = new Statistics();


            foreach (var grade in this.grades)
            {
                result.Add(grade);
            }


            return result;
        }

        public InMemoryBook(string name) : base(name)
        {
            this.grades = new List<double>();


        }

        public List<double> GetGrades()
        {
            return this.grades;
        }

        // EVENT

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // var file = File.AppendText($"./{Name}.txt");
            // file.WriteLine(grade);
            // file.Dispose();

            // This is like the with statement in python.
            using (var file = File.AppendText($"./{Name}.txt"))
            {
                file.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"./{Name}.txt"))
            {

                var line = reader.ReadLine();
                while (line != null)
                {
                    var num = double.Parse(line.Trim());
                    result.Add(num);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}