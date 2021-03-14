using System;
using System.Collections.Generic;

namespace GradeBook
{
    /// <summary>
    /// We need an electronic grade book to read the scores of an individual student and then
    /// compute some simple statistics from the scores.
    /// The grades are entered as floating point numbers from 0 to 100, and the statistics should
    /// show us the highest grade, the lowest grade, and the average grade.
    /// - The Project Manager
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // InMemoryBook book = new InMemoryBook("Scott's Grade Book");
            // book.GradeAdded += onGradeAdded;

            IBook book = new DiskBook("Scott's Grade Book");
            book.GradeAdded += onGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book name: {book.Name}");
            Console.WriteLine($"The lowest grade: {stats.LowestGrade:N1}");
            Console.WriteLine($"The highest grade: {stats.HighestGrade:N1}");
            Console.WriteLine($"The average grade: {stats.AverageGrade:N1}");
            Console.WriteLine($"The letter grade: {stats.LetterGrade}");
        }

        private static void EnterGrades(IBook book)
        {
            var done = false;

            while (!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    done = true;
                    continue;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void onGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}
