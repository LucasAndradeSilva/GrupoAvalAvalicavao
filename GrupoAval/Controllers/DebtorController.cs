
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
        private IContractInterface _contractService;
		private IInstallmentInterface _installmentService;

        public DebtorController(IDebtorInterface debtor, IPhoneInterface phoneService, IInstallmentInterface installmentService, IContractInterface contractService)
        {
            _debtorService = debtor;
            _phoneService = phoneService;
            _installmentService = installmentService;
            _contractService = contractService;
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
				var result = (Debtor)(await _debtorService.GetDebtor(id)).Data;
				result.Phones = (List<Phone>)(await _phoneService.ListPhones(id)).Data;
				result.Contracts = (List<Contract>)(await _contractService.ListContracts(id)).Data;
                return View(result);
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
                var result = (Debtor)(await _debtorService.GetDebtor(id)).Data;
                result.Phones = (List<Phone>)(await _phoneService.ListPhones(id)).Data;
                return View(result);
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
