namespace ZooKeeper.Validators
{
    class ValidatedObject
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public ValidatedObject(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
