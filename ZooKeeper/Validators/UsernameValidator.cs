using ZooKeeper.Exceptions;
using System.Text.RegularExpressions;
using System;

namespace ZooKeeper.Validators
{
    class UsernameValidator : AbstractValidator
    {
        public override ValidationException Validate(Credentials credentials)
        {
            string username = credentials.Username;
            Regex regex = new Regex(@"[A-Za-z0-9]{3,24}");
            if (!regex.IsMatch(username)){
                return new ValidationException("Login has to contain only latin letters and numbers and contain from 3 to 24 symbols", "login");
            }
            if (this.hadnler != null)
            {
                return this.hadnler.Validate(credentials);
            }
            return null;
        }
    }
}
