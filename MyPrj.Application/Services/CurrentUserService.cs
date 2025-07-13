using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MyPrj.Domain.Interface;

namespace MyPrj.Application.Services;

public class CurrentUserService : ICurrentUserService
{
    public Guid? UserId { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim != null)
        {
            UserId = Guid.Parse(userIdClaim.Value);
        }
    }
}