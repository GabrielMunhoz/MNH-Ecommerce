using MNH_Ecommerce.Domain.Utils;
using System;
using System.Collections.Generic;

namespace MNH_Ecommerce.Domain.Entity
{
    public class Demand
    {
        public int Id { get; set; }
        public DateTime DemandDate{ get; set; }
        public int UserId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CompleteAddress { get; set; }
        public string AddressNumber { get; set; }
        public int PayWayId { get; set; }
        public PayWay PayWay { get; set; }

        /// <summary>
        /// Pedido deve ter pelo menos um item de pedido
        /// ou muitos itens de pedidos
        /// </summary>
        public ICollection<ItemDemand> ItemDemands { get; set; }
    }
}
