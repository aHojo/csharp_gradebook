using System;
using Xunit;



namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            // Arrange section
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act Section
            var result = book.GetStatistics();
            // Assert section. 
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void NoGradesOver100()
        {
            InMemoryBook book = new InMemoryBook("");


            Assert.Throws<ArgumentException>(() => book.AddGrade(103.4));

            var result = book.GetGrades();
            Assert.Empty(result);
        }
    }
}
