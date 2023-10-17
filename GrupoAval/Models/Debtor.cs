

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrupoAval.Models
{
	public class Debtor
    {
		public int ID { get; set; }

		[DisplayName("Nome")]		
		[Required(ErrorMessage = "O nome é obrigátorio")]
		public string Name { get; set; }

		[DisplayName("CPF")]
        [MinLength(14, ErrorMessage = "Complete seu CPF")]
        [Required(ErrorMessage = "O CPF é obrigátorio")]
		public string CPF { get; set; }

		public List<Contract> Contracts { get; set; }
		public List<Phone> Phones { get; set; }
	}
}
