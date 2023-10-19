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
