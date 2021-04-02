using project.Factory;
using project.Model;

namespace project.Repository
{
    public class UserRepository
    {
        private static Project_DatabaseEntities db = new Project_DatabaseEntities();

        public static bool insertUser(string username, string password, string name, int role)
        {
            User user = UserFactory.Create(username, password, name, role);

            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            return false;

        }

    }
}