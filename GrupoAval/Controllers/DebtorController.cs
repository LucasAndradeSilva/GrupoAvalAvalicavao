
using GrupoAval.Models;
using GrupoAval.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using static GrupoAval.Models.Alert;

namespace GrupoAval.Controllers
{
	public class DebtorController : Controller
	{
		private IDebtorInterface _debtorService;
        private IPhoneInterface _phoneService;

        public DebtorController(IDebtorInterface debtor, IPhoneInterface phoneService)
        {
            _debtorService = debtor;
            _phoneService = phoneService;
        }

        public async Task<IActionResult> IndexAsync()
		{
			try
			{
				var result = await _debtorService.ListDebtor();

				if (!result.Success)
				{
					using (new Alert(AlertType.danger, result.Data, HttpContext))
					return View();
				}

				return View((IEnumerable<Debtor>)result.Data);
					
			}
			catch
			{ 
				return View();
			}
		}
		
		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var result = await _debtorService.GetDebtor(id);
                return View((Debtor)result.Data);
            }
			catch (Exception)
			{
                return View();
            }			
		}
		
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
                var result = await _debtorService.InsertDebtor(debtor);				

				if (result.Success)				
					using(new Alert(AlertType.success, result.Data, HttpContext));
				else
                    using (new Alert(AlertType.danger, result.Data, HttpContext));

                return RedirectToAction("Index");
			}
			catch
			{
				return RedirectToAction("Create");
			}
		}

		public async Task<IActionResult> EditAsync(int id)
		{
            try
            {
                var result = await _debtorService.GetDebtor(id);
                return View((Debtor)result.Data);
            }
            catch (Exception)
            {
                return View();
            }
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditAsync(Debtor debtor)
		{
			try
			{			
				var result = await _debtorService.UpdateDebtor(debtor);
				var phonesJoin = string.Join(',', debtor.Phones.Where(x => x.ID == 0).Select(x => x.PhoneNumber));
				await _phoneService.BulkInsertPhones(debtor.ID, phonesJoin);

                if (result.Success)
                    using (new Alert(AlertType.success, result.Data, HttpContext)) ;
                else
                    using (new Alert(AlertType.danger, result.Data, HttpContext)) ;

                return RedirectToAction("Edit", new { debtor.ID });
            }
			catch
			{
                return RedirectToAction("Edit");
            }
		}

		[HttpPost]		
		public async Task<IActionResult> DeleteAsync(int id)
        {
            try
			{
				var result = await _debtorService.DeleteDebtor(id);

                if (result.Success)
                    using (new Alert(AlertType.success, result.Data, HttpContext)) ;
                else
                    using (new Alert(AlertType.danger, result.Data, HttpContext)) ;

				return Ok();
			}
			catch
			{
				return Ok();
			}
		}
	}
}
