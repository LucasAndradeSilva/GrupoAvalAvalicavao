using GrupoAval.Models;

namespace GrupoAval.Services.Interface
{
	public interface IDebtorInterface
	{
        Task<Result> DeleteDebtor(int id);
        Task<Result> GetDebtor(int id);
        Task<Result> InsertDebtor(Debtor debtor);
        Task<Result> ListDebtor();
        Task<Result> UpdateDebtor(Debtor debtor);
    }
}
