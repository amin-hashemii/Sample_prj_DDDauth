namespace MyPrj.Domain.Interface;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}