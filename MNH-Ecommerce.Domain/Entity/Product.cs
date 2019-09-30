namespace MNH_Ecommerce.Domain.Entity
{
    public class Product : AbstractEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FileName { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddMenssageValidator("Nome - não pode ser vazio!");
            }
            if (Price == 0)
            {
                AddMenssageValidator("Preço - não pode ser vazio!");
            }
        }
    }
}
