using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discord_Anti_scam_Bot.Interfaces.Client
{
    public interface IBot
    {
        public Task Init(string token);
    }
}