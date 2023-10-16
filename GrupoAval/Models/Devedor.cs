using System.Diagnostics.Contracts;

namespace GrupoAval.Models
{
	public class Devedor
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public List<Contrato> Contratos { get; set; }
		public List<Telefone> Telefones { get; set; }
	}
}
