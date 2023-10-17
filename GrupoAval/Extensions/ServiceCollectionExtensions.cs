using GrupoAval.Services.Interface;
using GrupoAval.Services.Repository;
using GrupoAval.Data.Database;
using GrupoAval.Data;

namespace GrupoAval.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services)
        {      
            services.AddScoped<IContractInterface, ContractRepository>();
            services.AddScoped<IDebtorInterface, DebtorRepository>();
            services.AddScoped<IInstallmentInterface, InstallmentRepository>();
            services.AddScoped<IPhoneInterface, PhoneRepository>();
            services.AddScoped<IDatabaseIntaface, DatabaseRepository>();
        }
    }
}
