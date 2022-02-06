using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Discord_Anti_scam_Api
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

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}