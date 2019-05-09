using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
