namespace GrupoAval.Models
{
	public class Parcela
	{
		public int ID { get; set; }
		public int Contrato_ID { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime? DataPagamento { get; set; }
	}
}
