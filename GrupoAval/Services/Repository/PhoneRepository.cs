using GrupoAval.Data.Database;
using GrupoAval.Models;
using GrupoAval.Services.Interface;

namespace GrupoAval.Services.Repository
{
    public class PhoneRepository : IPhoneInterface
    {
        private IDatabaseIntaface database;

        public PhoneRepository(IDatabaseIntaface database)
        {
            this.database = database;
        }

        public async Task<Result> BulkInsertPhones(int Debtor_ID, string PhoneNumbers)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<string>("P_BulkInsertPhones", new
                {
                    Debtor_ID,
                    PhoneNumbers
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }

            return result;
        }

        public async Task<Result> DeletePhone(int ID)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<Result>("P_DeletePhone", new
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

		public async Task<Result> ListPhones(int Debtor_ID)
		{
			Result result;
			try
			{
				var data = await database.QueryMultipleAsync<Phone>("P_GetPhones", new
				{
					Debtor_ID
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
