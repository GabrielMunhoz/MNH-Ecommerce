using MNH_Ecommerce.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MNH_Ecommerce.Domain.Entity
{
    public class Demand : AbstractEntity
    {
        public int Id { get; set; }
        public DateTime DemandDate{ get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CompleteAddress { get; set; }
        public string AddressNumber { get; set; }
        public int PayWayId { get; set; }
        public virtual PayWay PayWay { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um item de pedido
        /// ou muitos itens de pedidos
        /// </summary>
        public virtual ICollection<ItemDemand> ItemDemands { get; set; }

        /// <summary>
        /// Tratamento de regras de negocio
        /// </summary>
        public override void Validate()
        {
            CleanMessagesValidator();

            if (ItemDemands.Any())
            {
                AddMenssageValidator("Pedido não Pode ficar sem item de pedido vazio!");
            }

            if (string.IsNullOrEmpty(CEP))
            {
                AddMenssageValidator("CEP não pode ser vazio!");
            }
        }
    }
}
