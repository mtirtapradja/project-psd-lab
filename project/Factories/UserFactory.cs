using project.Models;

namespace project.Factories
{
    public class UserFactory
    {
        public static User Create(string name, string username, string password, int role)
        {
            User u = new User();
            u.Name = name;
            u.Username = username;
            u.Password = password;
            u.RoleId = role;
            return u;
        }
    }
}