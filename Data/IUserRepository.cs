using DotnetAPI.Models;

namespace DotnetAPI.Data 
{
    public interface IUserRepository 
    {
         public bool SaveChanges();
         public void RemoveEntity<T>(T entityToRemove);
         public void AddEntity<T>(T entityToAdd);
        public IEnumerable<User> GetUsers();
        public User GetSingleUser(int userId);
        public UserSalary GetSingleUserSalary(int userId);
        public UserJobInfo GetSingleUserJobInfo(int userId);
    }
}