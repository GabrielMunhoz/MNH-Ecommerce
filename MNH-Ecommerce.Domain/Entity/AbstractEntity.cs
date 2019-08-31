using System.Collections.Generic;
using System.Linq;

namespace MNH_Ecommerce.Domain.Entity
{
    public abstract class AbstractEntity
    {
        protected List<string> _MenssagesValidator { get; set; }
        private List<string> MenssagesValidator
        {
            get { return _MenssagesValidator ?? (_MenssagesValidator = new List<string>()); }
        }
        protected bool IsValid {
            get { return !MenssagesValidator.Any(); }
        }
        protected abstract void Validate();

        protected void CleanMessagesValidator()
        {
            MenssagesValidator.Clear();
        }
        protected void AddMenssageValidator(string menssage)
        {
            MenssagesValidator.Add(menssage);
        }

    }
}
