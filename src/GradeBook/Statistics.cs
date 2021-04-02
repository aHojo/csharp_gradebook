using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
            private set { }
        }
        public double High;
        public double Low;
        public double Sum;

        public int Count;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0: // d gets assigned the value of result.Average. 
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }


        public Statistics()
        {
            Average = 0.0D;
            Low = double.MaxValue;
            High = double.MinValue;
            Sum = 0.0;
            Count = 0;
        }
    }
}