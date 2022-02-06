namespace Discord_Anti_scam_Web
{
	public class Program
	{
		public static Task Main(string[] args) => new Program().MainAsync(args);

		public async Task MainAsync(string[] args)
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath($"{Directory.GetCurrentDirectory()}")
				.AddJsonFile("appsettings.json")
				.AddUserSecrets("a2554f37-2d76-412c-9e24-72cb7b25e9f9")
				.Build();

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}