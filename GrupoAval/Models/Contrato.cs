namespace GrupoAval.Models
{
	public class Contrato
	{
		public int ID { get; set; }
		public int Devedor_ID { get; set; }
		public string NumeroContrato { get; set; }
		public List<Parcela> Parcelas { get; set; }
	}
}
