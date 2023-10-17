﻿
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
		private IDebtorInterface _debtor;

        public DebtorController(IDebtorInterface debtor)
        {
            _debtor = debtor;
        }
        
        public async Task<IActionResult> IndexAsync()
		{
			try
			{
				var result = await _debtor.ListDebtor();

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
				var result = await _debtor.GetDebtor(id);
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
                var result = await _debtor.InsertDebtor(debtor);

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
                var result = await _debtor.GetDebtor(id);
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
				var result = await _debtor.UpdateDebtor(debtor);

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
				var result = await _debtor.DeleteDebtor(id);

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
