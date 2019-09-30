using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Repository.Context;
using System.Linq;

namespace MNH_Ecommerce.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MNH_EcommerceContext mnh_EcommerceContext) : base(mnh_EcommerceContext)
        {
        }

        public User Get(string email)
        {
            return MnhEcommerceContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Login(string email, string password)
        {
            return MnhEcommerceContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
