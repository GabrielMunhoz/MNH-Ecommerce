using MNH_Ecommerce.Domain.Entity;

namespace MNH_Ecommerce.Domain.Contrats
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(string email, string password);
        User Get(string email);
    }
}
