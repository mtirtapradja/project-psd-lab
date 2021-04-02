using project.Model;

namespace project.Factory
{
    public class UserFactory
    {
        public static User Create(string username, string password, string name, int role)
        {
            User u = new User();
            u.Username = username;
            u.Password = password;
            u.Name = name;
            u.RoleId = role;
            return u;
        }
    }
}