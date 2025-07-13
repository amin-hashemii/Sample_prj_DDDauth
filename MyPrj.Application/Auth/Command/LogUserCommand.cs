using MediatR;

namespace MyPrj.Application.Auth.Command;

public class LogUserCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LogUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}