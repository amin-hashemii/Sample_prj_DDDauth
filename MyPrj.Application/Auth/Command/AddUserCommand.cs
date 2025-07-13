using MediatR;

namespace MyPrj.Application.Auth.Command;

public class AddUserCommand : IRequest<Unit>
{
    public AddUserCommand(string gmail, string password)
    {
        Gmail = gmail;
        Password = password;
    }

    public string Gmail { get; set; }
    public string Password { get; set; }
}
