using GrupoAval.Models;

namespace GrupoAval.Services.Interface
{
    public interface IPhoneInterface
    {
        Task<Result> BulkInsertPhones(int iD, string phonesJoin);
        Task<Result> DeletePhone(int id);
		Task<Result> ListPhones(int Debtor_ID);
	}
}
