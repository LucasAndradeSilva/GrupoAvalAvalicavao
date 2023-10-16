using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoAval.Controllers
{
	public class TelefoneController : Controller
	{
		// GET: TelefoneController
		public ActionResult Index()
		{
			return View();
		}

		// GET: TelefoneController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: TelefoneController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TelefoneController/Create
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

		// GET: TelefoneController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TelefoneController/Edit/5
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

		// GET: TelefoneController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: TelefoneController/Delete/5
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
