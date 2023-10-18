using GrupoAval.Models;
using GrupoAval.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrupoAval.Controllers
{
	public class PhoneController : Controller
	{
		private IPhoneInterface _phoneService;

        public PhoneController(IPhoneInterface phone)
        {
            _phoneService = phone;
        }

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
		public ActionResult DeleteAsync(int id)
		{
			return View();
		}
		
		[HttpPost]		
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var result = await _phoneService.DeletePhone(id);
                return Ok(result);
            }
            catch
            {
				return Ok(new Result("Erro ao deletar telefone", false));
			}
		}
	}
}
