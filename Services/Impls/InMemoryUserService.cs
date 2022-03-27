using System.Security.Claims;
using Hand_In_1_Simas_DNP.Entities.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Hand_In_1_Simas_DNP.Services.Impls;

// dummy database 
public class InMemoryUserService : IUserService
{

    private JsonContext jsonCont= new JsonContext();
    public Task<User?> GetUserAsync(string username)
    {
        User? find = UserList().Find(user => user.UserName.Equals(username));
        return Task.FromResult(find);
    }

    private List<User> UserList()
    {
        List<User> users = jsonCont.Forum.Users.ToList();
        return users;
    }


    public async Task CreateUserAsync(string username, string password)
    {
        if (IsValidUsername(username))
        {
            User newuser = new User(username, password);
            Console.WriteLine(newuser);
            List<User> temp = UserList();
            temp.Add(newuser);
            jsonCont.Forum.Users = temp;
            jsonCont.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Email invalid");
        }

    }

    bool IsValidUsername(string username)
    {
        var trimmedEmail = username.Trim();

        if (trimmedEmail.EndsWith(".")) {
            return false;
        }
        try {
            var addr = new System.Net.Mail.MailAddress(username);
            return addr.Address == trimmedEmail;
        }
        catch {
            return false;
        }
    }
    
    private List<Post> PostList()
    {
        List<Post> posts = jsonCont.Forum.Posts.ToList();
        return posts;
    }
    
    public Task<List<Post>> ReturnPostList()
    {
        List<Post> posts = jsonCont.Forum.Posts.ToList();
        return Task.Run(() => posts);
    }

    public async Task CreatePostAsync(string title, string body, string writtenBy)
    {
        Console.WriteLine("Title: " + title + "  Body: " + body);
        if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(body) || String.IsNullOrEmpty(writtenBy))
        {
            throw new Exception("Please fill in all the fields");
        }
        else
        {
            int id = PostList().Count + 1;
            Post newpost = new Post(title, body, writtenBy, id);

            List<Post> temp = PostList();

            temp.Add(newpost);
        
            jsonCont.Forum.Posts = temp;
            jsonCont.SaveChangesAsync();
        }

    }
}