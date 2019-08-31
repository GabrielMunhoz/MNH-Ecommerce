using System.Collections.Generic;

namespace MNH_Ecommerce.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        /// <summary>
        /// Nenhum ou muitos pedidos
        /// </summary>
        public ICollection<Demand> Demands { get; set; }
    }
}
