namespace Hand_In_1_Simas_DNP.Entities.Models;

public class User
{
    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    
    public string UserName { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return UserName + "  " + Password;
    }
}