using GrupoAval.Models;

namespace GrupoAval.Services.Interface
{
	public interface IDebtorInterface
	{
        Task<Result> InsertDebtor(Debtor debtor);
    }
}
