using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoAval.Controllers
{
	public class ParcelaController : Controller
	{
		// GET: ParcelaController
		public ActionResult Index()
		{
			return View();
		}

		// GET: ParcelaController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ParcelaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ParcelaController/Create
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

		// GET: ParcelaController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ParcelaController/Edit/5
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

		// GET: ParcelaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ParcelaController/Delete/5
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
