using System.Diagnostics.Contracts;

namespace GrupoAval.Models
{
	public class Debtor
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string CPF { get; set; }
		public List<Contract> Contracts { get; set; }
		public List<Phone> Phones { get; set; }
	}
}
