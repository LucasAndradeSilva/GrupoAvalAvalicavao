using GrupoAval.Models;
using GrupoAval.Services.Interface;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GrupoAval.Models.Alert;

namespace GrupoAval.Controllers
{
	public class InstallmentController : Controller
	{
        private IInstallmentInterface _installmentService;

        public InstallmentController(IInstallmentInterface installmentService)
        {
            this._installmentService = installmentService;
        }

        public async Task<IActionResult> ModalInstallment(int contractId)
        {
            try
            {
                var result = await _installmentService.ListInstallment(contractId);

                if (!result.Success)
                {
                    using (new Alert(AlertType.danger, result.Data, HttpContext))
                        return View();
                }

                return View((IEnumerable<Installment>)result.Data);

            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> PayInstallment(List<int> installmentsID)
        {
            try
            {
               
                return View();

            }
            catch
            {
                return View();
            }
        }
    }
}
