namespace GrupoAval.Models
{
	public class Contract
    {
		public int ContractId { get; set; }
		public int Debtor_ID { get; set; }
		public string ContractNumber { get; set; }
        public List<Installment> Installments { get; set; }

        public decimal CalculateAmountFees()
        {
            var updatedValue = 0m;
            var originalValue = 0m;
            var fisrtInstallment = Installments.FirstOrDefault(x => x.PaymentDate is null);

            if (fisrtInstallment != null)
            {
                originalValue = Installments
                    .Where(installment => installment.DueDate <= DateTime.Today) // Somente parcelas vencidas
                    .Sum(installment => installment.Amount);

                var today = DateTime.Today;
                var daysLate = (today - fisrtInstallment.DueDate).Days;

                var penalty = 4.80m;

                var interestRate = 0.02m;
                var interest = originalValue * interestRate * daysLate;

                var fees = (originalValue + penalty + interest) * 0.10m;

                updatedValue = originalValue + penalty + interest + fees;
            }

            return updatedValue;
        }
    }
}
