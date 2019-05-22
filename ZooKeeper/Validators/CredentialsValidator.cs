using ZooKeeper.Exceptions;

namespace ZooKeeper.Validators
{
    class CredentialsValidator : AbstractValidator
    {
        public override ValidationException Validate(ValidatedObject credentials)
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
