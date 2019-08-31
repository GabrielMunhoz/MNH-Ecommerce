using MNH_Ecommerce.Domain.Enumerados;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNH_Ecommerce.Domain.Utils
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool IsBoleto {
            get { return Id == (int)TipoFormaPagamentoEnum.Boleto; }
                
        }
        public bool IsCartaoCredito{
            get { return Id == (int)TipoFormaPagamentoEnum.CartaoCredito; }
                
        }
        public bool IsDeposito {
            get { return Id == (int)TipoFormaPagamentoEnum.Deposito; }
                
        }
        public bool NaoFoiDefinido {
            get { return Id == (int)TipoFormaPagamentoEnum.NaoDefinido; }
                
        }
    }
}
