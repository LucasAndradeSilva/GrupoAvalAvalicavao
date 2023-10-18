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

        // GET: ContratoController
        public ActionResult Index()
		{
			return View();
		}

		// GET: ContratoController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ContratoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ContratoController/Create
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

		// GET: ContratoController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ContratoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ContratoController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ContratoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
