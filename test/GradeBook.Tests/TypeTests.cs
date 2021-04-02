using System;
using Xunit;



namespace GradeBook.Tests
{
    public delegate String WriteLogDelegate(string logMessage);

    public class TypeTests
    {

        private int count = 0;

        [Fact]
        public void WriteLogDelegateToMethod()
        {
            /* SINGLE DELEGATE
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMessage); // passing in the method here. 
            // or can do log = ReturnMessage
            */

            /* MULTI-cast DELEGATE */
            WriteLogDelegate log = ReturnMessage;
            // Here is how we do multi-cast delegate. 
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");

            Assert.Equal(3, count);
        }

        // ReturnMessage matches the delegate signature.
        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Andrew";


            String upper = MakeUpperCase(name);
            Assert.Equal("Andrew", name);
            Assert.Equal("ANDREW", upper);
        }

        private String MakeUpperCase(string parameter)
        {
            String converted = parameter.ToUpper();
            return converted;
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);


        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);


        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);


        }

        private void SetName(InMemoryBook book1, string name)
        {
            book1.Name = name;
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
