using GrupoAval.Service.Interface;
using GrupoAval.Services.Interface;
using GrupoAval.Services.Repository;

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
        }
    }
}
