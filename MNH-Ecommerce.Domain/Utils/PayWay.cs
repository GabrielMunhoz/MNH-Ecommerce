using MNH_Ecommerce.Domain.Enumerators;

namespace MNH_Ecommerce.Domain.Utils
{
    public class PayWay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //boleto
        public bool IsPaymentSlip {
            get { return Id == (int)TypePayWay.PaymentSlip; }
                
        }
        public bool IsCredCard{
            get { return Id == (int)TypePayWay.CredCard; }
                
        }
        public bool IsDeposit {
            get { return Id == (int)TypePayWay.Deposit; }
                
        }
        public bool PaymentUdefined {
            get { return Id == (int)TypePayWay.PaymentUndefined; }
                
        }

    }
}
