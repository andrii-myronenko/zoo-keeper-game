using System;
using ZooKeeper.Repositories;
using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.AccessManager
{
    class ProtectedZooLoader : IZooLoader
    {
        ZooLoader zooLoader = new ZooLoader();

        public ZooPark GetZoo(Credentials credentials)
        {
            var validator = new CredentialsValidator();
            var validationException = validator.Validate(credentials);
            if (validationException != null)
            {
                throw new Exception($"Your {validationException.NotValidField} is not valid, " +
                                    $"Exception: {validationException.Message}");
            }
            if (UserRepository.UserAllowedToAccess(credentials.Username, credentials.Password))
            {
                return zooLoader.GetZoo(credentials);
            }
            throw new Exception("There is no user with such login-password match");
        }
    }
}
