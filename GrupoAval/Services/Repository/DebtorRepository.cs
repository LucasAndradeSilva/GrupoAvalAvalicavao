using GrupoAval.Data.Database;
using GrupoAval.Models;
using GrupoAval.Services.Interface;
using System.Numerics;

namespace GrupoAval.Services.Repository
{
    public class DebtorRepository : IDebtorInterface
    {
        private IDatabaseIntaface database;

        public DebtorRepository(IDatabaseIntaface database)
        {
            this.database = database;
        }

        public async Task<Result> DeleteDebtor(int ID)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<Result>("P_DeleteDebtor", new
                {
                    ID
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }

            return result;
        }

        public async Task<Result> GetDebtor(int ID)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<Debtor>("P_GetDebtor", new
                {
                    ID                   
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }

            return result;
        }

        public async Task<Result> InsertDebtor(Debtor debtor)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<string>("P_InsertDebtor", new
                {
                    debtor.Name,
                    debtor.CPF
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }
            
            return result;
        }

        public async Task<Result> ListDebtor()
        {            
            try
            {
                var list = await database.QueryMultipleAsync<Debtor>("P_GetAllDebtors");                                
                var result = new Result(list);
                return result;
            }
            catch (Exception ex)
            {
                var result = new Result("Ocorreu um erro", false);
				return result;
			}            
        }

        public async Task<Result> UpdateDebtor(Debtor debtor)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<string>("P_UpdateDebtor", new
                {
                    debtor.ID,
                    debtor.Name,
                    debtor.CPF
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }

            return result;
        }
    }
}
