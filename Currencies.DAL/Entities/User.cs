namespace Currencies.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public User() { }
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
