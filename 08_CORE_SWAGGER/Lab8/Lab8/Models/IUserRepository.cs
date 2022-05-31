using Microsoft.EntityFrameworkCore;

namespace Lab8.Models
{
    public interface IUserRepository : IRepository<User>
    {
        Users Get();
        User GetSingle(int id);
    }
}
