﻿using System.Collections.Generic;

namespace MNH_Ecommerce.Domain.Entity
{
    public class User : AbstractEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin{ get; set; }

        /// <summary>
        /// Nenhum ou muitos pedidos
        /// </summary>
        public virtual ICollection<Demand> Demands { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
            {
                AddMenssageValidator("Email - não pode ser vazio!");
            }
            if (string.IsNullOrEmpty(Name))
            {
                AddMenssageValidator("Nome - não pode ser vazio!");
            }
        }
    }
}
