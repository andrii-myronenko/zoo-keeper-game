using ZooKeeper.Exceptions;

namespace ZooKeeper.Validators
{
    abstract class AbstractValidator
    {
        protected AbstractValidator hadnler;

        public void SetHandler(AbstractValidator handler) {
            this.hadnler = handler;
        }

        public abstract ValidationException Validate(ValidatedObject toValidate);
    }
}
