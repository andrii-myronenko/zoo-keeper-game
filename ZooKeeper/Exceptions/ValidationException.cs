using System;

namespace ZooKeeper.Exceptions
{
    class ValidationException : Exception
    {
        public ValidationException(string message, string notValidField) : base(message) {
            NotValidField = notValidField;
        }

        public string NotValidField { get; set; }
    }
}
