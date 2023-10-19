using GrupoAval.Models;
using GrupoAval.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GrupoAval.Models.Alert;

namespace GrupoAval.Controllers
{
	public class ContractController : Controller
	{
		private IContractInterface _contractService;

        public ContractController(IContractInterface contractService)
        {
            this._contractService = contractService;
        }

		[HttpPost]		
		public async Task<IActionResult> CreateAsync(int debtor_id)
		{
			try
			{
				var result = await _contractService.CreateContract(debtor_id);

                if (result.Success)
                    using (new Alert(AlertType.success, result.Data, HttpContext)) ;
                else
                    using (new Alert(AlertType.danger, result.Data, HttpContext)) ;

				return Ok(result);
            }
			catch
			{
				return Ok(new Result("Erro ao criar contrato", false));
			}
		}
	}
}
