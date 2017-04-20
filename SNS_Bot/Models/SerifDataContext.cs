using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tweetBot.Models;

namespace tweetBot.Context
{
    class SerifDataContext : DbContext
    {

        public SerifDataContext() : base("name=SerifDataContext") {}


        public DbSet<SerifData> Serifs { get; set; }

        public DbSet<SendReplyUsers> SendReplyUsers { get; set; }
    }
}
