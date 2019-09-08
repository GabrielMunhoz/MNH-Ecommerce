using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Repository.Context;

namespace MNH_Ecommerce.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MNH_EcommerceContext mnh_EcommerceContext) : base(mnh_EcommerceContext)
        {
        }
    }
}
