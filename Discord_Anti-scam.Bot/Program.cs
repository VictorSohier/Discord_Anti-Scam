using Discord_Anti_scam_Bot.Models.Client;
using Microsoft.Extensions.Configuration;

namespace Discord_Anti_scam_Bot
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
			Bot bot = new();
			await bot.Init(configuration["Token"]);
			await Task.Delay(-1);
		}
	}
}