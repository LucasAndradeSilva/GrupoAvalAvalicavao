using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoAval.Controllers
{
	public class DevedorController : Controller
	{
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

		// POST: DevedorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(IFormCollection collection)
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
