using GrupoAval.Models;

namespace GrupoAval.Services.Interface
{
    public interface IInstallmentInterface
    {
        Task<Result> ListInstallment(int contractId);
    }
}
