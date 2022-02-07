using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord_Anti_scam.Core.Enums;
using Discord_Anti_scam.Infrastructure.Models;
using Discord_Anti_scam.Infrastructure.Models.Logging;
using Discord_Anti_scam_Bot.Interfaces.Client;

namespace Discord_Anti_scam_Bot.Models.Client
{
    public class Bot : IBot
    {
        protected DiscordSocketClient _client { get; }
		protected AggregateLog _logger { get; }

		public Bot()
		{
			_client = new();
			_logger = new(
				new StreamLogger(
					Console.OpenStandardOutput(),
					Encoding.UTF8,
					"{3}{4}[{2}]\u001b[0m[{1}] | {5}\n",
					ColorModeEnum.RGB),
				new FileLogger(
					"log.txt",
					Encoding.UTF8,
					"[{2}][{1}] | {3}\n"));
		}

		public async Task Init(string token)
		{
			_logger.Log(LogLevelEnum.INFO, "Logging in");
			await _client.LoginAsync(TokenType.Bot, token);
			_logger.Log(LogLevelEnum.INFO, "Bot logged in");
		}
    }
}