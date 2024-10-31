namespace Practice.Exceptions;

class NotInTheList : Exception
{
    public class CustomNotInTheListException : Exception
    {
        public CustomNotInTheListException() { }
        public CustomNotInTheListException(string message) : base(message) { }
    }
}