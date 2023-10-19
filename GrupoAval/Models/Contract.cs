namespace GrupoAval.Models
{
	public class Contract
    {
		public int ContractId { get; set; }
		public int Debtor_ID { get; set; }
		public string ContractNumber { get; set; }
        public List<Installment> Installments { get; set; }
        public decimal Amount
        {
            get
            {
                return Installments
                   .Where(installment => installment.DueDate <= DateTime.Today)
                   .Sum(installment => installment.Amount);
            }
        }
        public decimal AmountFess { 
            get {
                return CalculateAmountFees();
            }
        }
        public decimal Fees { 
            get
            {
                return CalculateFees();
            }
        }
        public int QtdDueInstallments
        {
            get
            {
                return Installments
                   .Where(installment => installment.DueDate < DateTime.Today).Count();                   
            }
        }
        private decimal CalculateAmountFees()
        {
            var updatedValue = 0m;
            var originalValue = Installments
                   .Where(installment => installment.DueDate <= DateTime.Today)
                   .Sum(installment => installment.Amount); 
            var fisrtInstallment = Installments.FirstOrDefault(x => x.PaymentDate is null);

            if (fisrtInstallment != null)
            {               
                var fees = CalculateFees();

                updatedValue = originalValue + fees;
            }

            return updatedValue;
        }
        private decimal CalculateFees()
        {
            var originalValue = 0m;
            var fisrtInstallment = Installments.FirstOrDefault(x => x.PaymentDate is null);

            originalValue = Installments
                   .Where(installment => installment.DueDate < DateTime.Today)
                   .Sum(installment => installment.Amount);

            var today = DateTime.Today;
            var daysLate = (today - fisrtInstallment.DueDate.Value).Days;

            var penalty = 4.80m;

            var interestRate = 0.02m;
            var interest = originalValue * interestRate * daysLate;

            var fees = (penalty + interest) * 0.10m;

            return fees;
        }
    }
}
