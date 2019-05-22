using System;
using ZooKeeper.Repositories;
using ZooKeeper.ZooManager;
using ZooKeeper.Validators;

namespace ZooKeeper.AccessManager
{
    class ProtectedZooLoader : IZooLoader
    {
        ZooLoader zooLoader = new ZooLoader();

        public ZooPark GetZoo(string username, string password)
        {
            var validator = new CredentialsValidator();
            var validationException = validator.Validate(new ValidatedObject(username, password));
            if (validationException != null)
            {
                throw new Exception($"Your {validationException.NotValidField} is not valid, " +
                                    $"Exception: {validationException.Message}");
            }
            if (ApplicationRepository.CheckUserAllowedToAccess(username, password))
            {
                return zooLoader.GetZoo(username, password);
            }
            throw new Exception("There is no user with such login-password match");
        }
    }
}
