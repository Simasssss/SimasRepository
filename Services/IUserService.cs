using Hand_In_1_Simas_DNP.Entities.Models;

namespace Hand_In_1_Simas_DNP.Services;

public interface IUserService
{
    public Task<User?> GetUserAsync(string username);
    public Task CreateUserAsync(string username, string password);
    public Task CreatePostAsync(string username, string password, string writtenBy);
    public Task<List<Post>> ReturnPostList();
}