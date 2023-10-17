
using GrupoAval.Models;
using GrupoAval.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GrupoAval.Models.Alert;

namespace GrupoAval.Controllers
{
	public class DebtorController : Controller
	{
		private IDebtorInterface _debtor;

        public DebtorController(IDebtorInterface debtor)
        {
            _debtor = debtor;
        }

        // GET: DevedorController
        public IActionResult Index()
		{
			return View();
		}

		// GET: DevedorController/Details/5
		public IActionResult Details(int id)
		{
			return View();
		}

		// GET: DevedorController/Create
		public IActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateAsync(Debtor debtor)
		{
			try
			{
                var result = await _debtor.InsertDebtor(debtor);

				if (result.Success)				
					using(new Alert(AlertType.success, result.Message, HttpContext));
				else
                    using (new Alert(AlertType.danger, result.Message, HttpContext));

                return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: DevedorController/Edit/5
		public IActionResult Edit(int id)
		{
			return View();
		}

		// POST: DevedorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, IFormCollection collection)
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

		// GET: DevedorController/Delete/5
		public IActionResult Delete(int id)
		{
			return View();
		}

		// POST: DevedorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id, IFormCollection collection)
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
