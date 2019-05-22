using ZooKeeper.Exceptions;
using System.Text.RegularExpressions;

namespace ZooKeeper.Validators
{
    class PasswordValidator : AbstractValidator
    {
        public override ValidationException Validate(ValidatedObject credentials)
        {
            string password = credentials.Password;
            Regex regex = new Regex(@"[A-Za-z0-9]{3,24}");
            if (!regex.IsMatch(password))
            {
                return new ValidationException("Pasword has to contain only latin letters and numbers and contain from 3 to 24 symbols", "password");
            }
            if (this.hadnler != null)
            {
                return this.hadnler.Validate(credentials);
            }
            return null;
        }
    }
}
