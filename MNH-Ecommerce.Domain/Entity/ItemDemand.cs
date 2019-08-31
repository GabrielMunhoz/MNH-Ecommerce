namespace MNH_Ecommerce.Domain.Entity
{
    public class ItemDemand : AbstractEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        protected override void Validate()
        {
            if (Quantity == 0)
            {
                AddMenssageValidator("Quantidade - não pode ser vazio!");
            }
        }
    }
}
