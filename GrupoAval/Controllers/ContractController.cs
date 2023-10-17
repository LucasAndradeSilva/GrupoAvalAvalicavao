using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoAval.Controllers
{
	public class ContractController : Controller
	{
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
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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
