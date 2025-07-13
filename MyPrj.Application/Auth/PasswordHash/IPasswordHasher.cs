namespace MyPrj.Application.Auth.PasswordHash;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool Verify(string password, string hashedPassword);
}