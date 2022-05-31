using Microsoft.EntityFrameworkCore;

namespace Lab8.Models
{
    public class UserRepository : GenericRepository<ApplicationContext, User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext) { }

        public Users Get() =>new Users() { usersList = _dbContext.Users.ToList() };
    
        public User GetSingle(int id) => _dbContext.Users.Single(el => el.Id == id);
    }
}
