using System.ComponentModel;

namespace GrupoAval.Models
{
	public class Installment
    {
        [DisplayName("Cod. Parcela")]
		public int InstallmentId { get; set; }
		public int Contract_ID { get; set; }
        [DisplayName("Valor")]
		public decimal Amount { get; set; }
        [DisplayName("Data de Vencimento")]
		public DateTime? DueDate { get; set; }
        [DisplayName("Data de Pagamento")]
        public DateTime? PaymentDate { get; set; }
		public bool	Due {
			get
			{
				return DueDate < DateTime.Today;
			}
		}
        public decimal AmountFess
        {
            get
            {
                return CalculateAmountFees();
            }
        }
        public decimal Fees
        {
            get
            {
                return CalculateFees();
            }
        }
        private decimal CalculateAmountFees()
        {
            var updatedValue = this.Amount;                        

            if (Due)
            {
                var fees = CalculateFees();

                updatedValue += fees;
            }

            return updatedValue;
        }
        private decimal CalculateFees()
        {
            var originalValue = this.Amount;                        

            var today = DateTime.Today;
            var daysLate = (today - this.DueDate.Value).Days;

            var penalty = 4.80m;

            var interestRate = 0.02m;
            var interest = originalValue * interestRate * daysLate;

            var fees = (penalty + interest) * 0.10m;

            return fees;
        }
    }
}
