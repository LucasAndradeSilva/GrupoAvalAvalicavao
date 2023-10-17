namespace GrupoAval.Models
{
	public class Installment
    {
		public int ID { get; set; }
		public int Contract_ID { get; set; }
		public decimal Amount { get; set; }
		public DateTime DueDate { get; set; }
		public DateTime? PaymentDate { get; set; }
	}
}
