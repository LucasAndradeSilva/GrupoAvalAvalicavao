using GrupoAval.Data.Database;
using GrupoAval.Models;
using GrupoAval.Services.Interface;
using System.Diagnostics.Contracts;

namespace GrupoAval.Services.Repository
{
    public class InstallmentRepository : IInstallmentInterface
    {
        private IDatabaseIntaface database;

        public InstallmentRepository(IDatabaseIntaface database)
        {
            this.database = database;
        }

        public async Task<Result> ListInstallment(int ContractID)
        {
            try
            {
                var list = await database.QueryMultipleAsync<Installment>("P_ListInstallmentsByContractID", new
                {
                    ContractID
                });
                var result = new Result(list);
                return result;
            }
            catch (Exception ex)
            {
                var result = new Result("Ocorreu um erro", false);
                return result;
            }
        }
    }
}
