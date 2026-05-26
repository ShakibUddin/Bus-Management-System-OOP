public class User
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string Phone { get; }
    public DateTime CreatedAt { get; }

    public User(int id, string name, string email, string mobile)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = mobile;
        CreatedAt = DateTime.Now;
    }
}