using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooKeeper.Exceptions;

namespace ZooKeeper.Validators
{
    class CredentialsValidator : AbstractValidator
    {
        public override ValidationException Validate(Credentials credentials)
        {
            return this.hadnler.Validate(credentials);
        }

        public CredentialsValidator()
        {
            AbstractValidator usernameValidator = new UsernameValidator();
            usernameValidator.SetHandler(new PasswordValidator());
            this.SetHandler(usernameValidator);
        }
    }
}
