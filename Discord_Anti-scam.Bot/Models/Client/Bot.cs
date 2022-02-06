using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord_Anti_scam_Bot.Interfaces.Client;

namespace Discord_Anti_scam_Bot.Models.Client
{
    public class Bot : IBot
    {
        protected DiscordSocketClient _client;

		public Bot()
		{
			_client = new();
		}

		public async Task Init(string token)
		{
			await _client.LoginAsync(TokenType.Bot, token);
			Console.WriteLine("Bot Initiated!");
		}
    }
}