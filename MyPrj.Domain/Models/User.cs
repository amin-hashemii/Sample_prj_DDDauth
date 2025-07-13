namespace MyPrj.Domain.Models;

public class User
{
    
    public User() {}

    public User( string email, string password)
    {
        Id = Guid.NewGuid();  
        Email = email;
        Password = password;
    }


    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}