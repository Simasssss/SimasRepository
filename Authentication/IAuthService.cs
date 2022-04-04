using System.Security.Claims;
using Hand_In_1_Simas_DNP.Entities.Models;

namespace Hand_In_1_Simas_DNP.Authentication;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);

    public Task CreateUserAsync(string username, string password);
    public Task CreatePostAsync(string title, string body, string writtenBy);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public ICollection<Post> ReturnPostList();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}