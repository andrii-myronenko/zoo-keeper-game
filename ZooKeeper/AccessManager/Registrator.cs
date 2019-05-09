using System;
using ZooKeeper.Validators;
using ZooKeeper.Repositories;

namespace ZooKeeper.AccessManager
{
    public static class Registrator
    {
        public static void RegisterUser(string username, string password)
        {

            var validator = new CredentialsValidator();
            var validationException = validator.Validate(new Credentials(username, password));
            if (validationException != null)
            {
                throw new Exception($"Your {validationException.NotValidField} is not valid, " +
                                    $"Exception: {validationException.Message}");
            }
            UserRepository.AddUser(username, password);
        }
    }
}
