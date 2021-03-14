using System;

namespace GradeBook
{
    public class Statistics
    {

        public double HighestGrade;
        public double LowestGrade;
        public double AverageGrade
        {
            get
            {
                return Sum / Count;
            }
        }
        public char LetterGrade
        {
            get
            {
                switch (AverageGrade)
                {
                    case var grade when grade >= 90.0:
                        return 'A';

                    case var grade when grade >= 80.0:
                        return 'B';

                    case var grade when grade >= 70.0:
                        return 'C';

                    case var grade when grade >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public Statistics()
        {
            // AverageGrade = 0.0;
            Sum = 0.0;
            Count = 0;
            HighestGrade = double.MinValue;
            LowestGrade = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            LowestGrade = Math.Min(number, LowestGrade);
            HighestGrade = Math.Max(number, HighestGrade);
        }
    }
}