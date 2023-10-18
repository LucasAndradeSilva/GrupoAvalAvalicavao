using GrupoAval.Data.Database;
using GrupoAval.Models;
using GrupoAval.Services.Interface;

namespace GrupoAval.Services.Repository
{
    public class ContractRepository : IContractInterface
    {
        private IDatabaseIntaface database;

        public ContractRepository(IDatabaseIntaface database)
        {
            this.database = database;
        }

        public async Task<Result> CreateContract(int DebtorID)
        {
            Result result;
            try
            {
                var data = await database.QueryFirstAsync<string>("P_CreateContractWithInstallments", new
                {
                    DebtorID
                });
                result = new Result(data);
            }
            catch (Exception ex)
            {
                result = new Result("Ocorreu um erro");
            }

            return result;
        }

        public async Task<Result> ListContracts(int debtorID)
        {
            var contracts = await database.QueryAsync("P_ListContractsAndInstallmentsByDebtorID", gridReader =>
            {
                var contractDictionary = new Dictionary<int, Contract>();
                var results = gridReader.Read<Contract, Installment, Contract>(
                    (contract, installment) =>
                    {
                        if (!contractDictionary.TryGetValue(contract.ContractId, out var existingContract))
                        {
                            existingContract = contract;
                            existingContract.Installments = new List<Installment>();
                            contractDictionary.Add(contract.ContractId, existingContract);
                        }
                        existingContract.Installments.Add(installment);
                        return existingContract;
                    },
                    splitOn: "ContractID, InstallmentID"
                ).Distinct();
                return results.ToList();
            }, new { DebtorID = debtorID });

            var result = new Result(contracts);
            return result;
        }
    }
}
