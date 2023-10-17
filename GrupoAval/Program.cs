using GrupoAval.Extensions;

namespace GrupoAval
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			builder.Services.AddControllersWithViews();
			builder.Services.AddDependencyInjectionCustom();
			builder.Services.AddSession();

            var app = builder.Build();
			
			if (!app.Environment.IsDevelopment())
			{				
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession(); 
			app.UseRouting();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Debtor}/{action=Index}/{id?}");

			app.Run();
		}
	}
}