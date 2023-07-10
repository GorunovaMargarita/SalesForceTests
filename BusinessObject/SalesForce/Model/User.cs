namespace BusinessObject.SalesForce.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public override string? ToString()
        {
            return $"Name: {Name}, password: {Password}";
        }
    }
}