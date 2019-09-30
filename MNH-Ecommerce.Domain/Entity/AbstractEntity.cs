using System.Collections.Generic;
using System.Linq;

namespace MNH_Ecommerce.Domain.Entity
{
    public abstract class AbstractEntity
    {
        protected List<string> _MessagesValidator { get; set; }
        private List<string> MessagesValidator
        {
            get { return _MessagesValidator ?? (_MessagesValidator = new List<string>()); }
        }
        public bool IsValid {
            get { return !MessagesValidator.Any(); }
        }
        public abstract void Validate();

        protected void CleanMessagesValidator()
        {
            MessagesValidator.Clear();
        }
        protected void AddMenssageValidator(string menssage)
        {
            MessagesValidator.Add(menssage);
        }

        public string GetMessageValidate()
        {
            return string.Join(" . ", MessagesValidator);
        }

    }
}
