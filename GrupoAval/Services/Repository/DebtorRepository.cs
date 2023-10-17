using GrupoAval.Data.Database;
using GrupoAval.Models;
using GrupoAval.Services.Interface;

namespace GrupoAval.Services.Repository
{
    public class DebtorRepository : IDebtorInterface
    {
        private IDatabaseIntaface database;

        public DebtorRepository(IDatabaseIntaface database)
        {
            this.database = database;
        }

        public async Task<Result> InsertDebtor(Debtor debtor)
        {
            Result result;
            try
            {
                var msg = await database.QueryFirstAsync<string>("P_InsertDebtor", new
                {
                    debtor.Name,
                    debtor.CPF
                });
                result = new Result(msg);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro", false);
            }
            
            return result;
        }
    }
}
