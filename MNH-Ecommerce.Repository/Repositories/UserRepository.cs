using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;

namespace MNH_Ecommerce.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        public UserRepository()
        {

        }
    }
}
