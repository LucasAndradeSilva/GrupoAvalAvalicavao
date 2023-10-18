using GrupoAval.Models;

namespace GrupoAval.Services.Interface
{
    public interface IContractInterface
    {
        Task<Result> CreateContract(int debtor_id);
        Task<Result> ListContracts(int id);
    }
}
